using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Infrastructure.Services;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using NSubstitute;
using Shouldly;

namespace Mc2.CrudTest.UnitTests.Application;

public class CreateCustomerHandlerTests
{

    Task Act(CreateCustomerCommand command)
            => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_Throws_CustomerEmailAlreadyExistsException_When_Email_Duplicate()
    {
        _readService.ExistsByEmailAsync(_createCustomerCommand.Email).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(_createCustomerCommand));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CustomerEmailAlreadyExistsException>();
    }

    [Fact]
    public async Task HandleAsync_Throws_CustomerAlreadyExistsException_When_Email_Duplicate()
    {
        _readService.ExistsDuplicateAsync(_createCustomerCommand.Firstname, _createCustomerCommand.Lastname,
            _createCustomerCommand.DateOfBirth).Returns(true);

        var exception = await Record.ExceptionAsync(() => Act(_createCustomerCommand));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CustomerAlreadyExistsException>();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("0")]
    [InlineData("")]
    public async Task HandleAsync_Throws_WrongPhoneNumberException(string phoneNumber)
    {
        var createCustomerCommand = new CreateCustomerCommand(Guid.NewGuid(), "hamed", "lohi", new DateTime(1990, 7, 8),
            phoneNumber, "lohi.hamed@gmail.com", "123456789");
        _readService.ExistsByEmailAsync(createCustomerCommand.Email).Returns(false);
        _readService.ExistsDuplicateAsync(createCustomerCommand.Firstname, createCustomerCommand.Lastname,
            createCustomerCommand.DateOfBirth).Returns(false);

        var exception = await Record.ExceptionAsync(() => Act(createCustomerCommand));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<WrongPhoneNumberException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_Success()
    {
        _readService.ExistsByEmailAsync(_createCustomerCommand.Email).Returns(false);
        _readService.ExistsDuplicateAsync(_createCustomerCommand.Firstname, _createCustomerCommand.Lastname,
            _createCustomerCommand.DateOfBirth).Returns(false);

        //_phoneService.ValidatePhoneNumberAsync(_createCustomerCommand.PhoneNumber).Returns(string.Empty);

        _factory.Create(_createCustomerCommand.Id, _createCustomerCommand.Firstname, _createCustomerCommand.Lastname,
            _createCustomerCommand.DateOfBirth, _createCustomerCommand.PhoneNumber, Arg.Any<CustomerEmail>(),
            Arg.Any<CustomerBankAccountNumber>())
            .Returns(default(Customer));

        var exception = await Record.ExceptionAsync(() => Act(_createCustomerCommand));

        exception.ShouldBeNull();
        await _repository.Received(1).AddAsync(Arg.Any<Customer>());
    }

    #region ARRANGE

    private readonly ICommandHandler<CreateCustomerCommand> _commandHandler;
    private readonly ICustomerRepository _repository;
    private readonly IPhoneNumberService _phoneService;
    private readonly ICustomerReadService _readService;
    private readonly ICustomerFactory _factory;
    private CreateCustomerCommand _createCustomerCommand;

    public CreateCustomerHandlerTests()
    {
        _repository = Substitute.For<ICustomerRepository>();
        _phoneService = new PhoneNumberService();
        _readService = Substitute.For<ICustomerReadService>();
        _factory = Substitute.For<ICustomerFactory>();
        _commandHandler = new CreateCustomerHandler(_repository, _factory, _readService, _phoneService);
        _createCustomerCommand = new CreateCustomerCommand(Guid.NewGuid(), "hamed", "lohi", new DateTime(1990, 7, 8),
            "09149012500", "lohi.hamed@gmail.com", "123456789");
    }

    #endregion

}