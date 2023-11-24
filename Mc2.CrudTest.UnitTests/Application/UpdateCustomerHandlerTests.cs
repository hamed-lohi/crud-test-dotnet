using Mc2.CrudTest.Application.Commands;
using Mc2.CrudTest.Application.Commands.Handlers;
using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Commands;
using NSubstitute;
using Shouldly;

namespace Mc2.CrudTest.UnitTests.Application;

public class UpdateCustomerHandlerTests
{

    Task Act(UpdateCustomerCommand command)
            => _commandHandler.HandleAsync(command);

    [Fact]
    public async Task HandleAsync_Throws_CustomerNotFoundException()
    {
        _repository.GetAsync(_updateCustomerCommand.CustomerId).Returns(default(Customer?));

        var exception = await Record.ExceptionAsync(() => Act(_updateCustomerCommand));

        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CustomerNotFoundException>();
    }

    [Fact]
    public async Task HandleAsync_Calls_Repository_Success()
    {
        var customer = _factory.Create(_updateCustomerCommand.CustomerId, _updateCustomerCommand.Firstname, _updateCustomerCommand.Lastname,
            _updateCustomerCommand.DateOfBirth, _updateCustomerCommand.PhoneNumber, _updateCustomerCommand.Email,
            _updateCustomerCommand.BankAccountNumber);
        _repository.GetAsync(_updateCustomerCommand.CustomerId).Returns(customer);

        //_phoneService.ValidatePhoneNumberAsync(_createCustomerCommand.PhoneNumber).Returns(string.Empty);

        var exception = await Record.ExceptionAsync(() => Act(_updateCustomerCommand));

        exception.ShouldBeNull();
        await _repository.Received(1).UpdateAsync(Arg.Any<Customer>());
    }

    #region ARRANGE

    private readonly ICommandHandler<UpdateCustomerCommand> _commandHandler;
    private readonly ICustomerRepository _repository;
    private readonly ICustomerFactory _factory;
    private UpdateCustomerCommand _updateCustomerCommand;

    public UpdateCustomerHandlerTests()
    {
        _repository = Substitute.For<ICustomerRepository>();
        _commandHandler = new UpdateCustomerHandler(_repository);
        _factory = new CustomerFactory();
        _updateCustomerCommand = new UpdateCustomerCommand(Guid.NewGuid(), "hamed", "lohi", new DateTime(1990,7,8),
            "09149012500", "lohi.hamed@gmail.com", "123456789");
    }

    #endregion

}