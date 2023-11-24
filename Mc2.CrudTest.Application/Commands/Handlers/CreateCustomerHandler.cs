using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands.Handlers;

public class CreateCustomerHandler : ICommandHandler<CreateCustomerCommand>
{
    private readonly ICustomerRepository _repository;
    private readonly ICustomerFactory _factory;
    private readonly ICustomerReadService _readService;
    private readonly IPhoneNumberService _phoneService;



    public CreateCustomerHandler(ICustomerRepository repository, ICustomerFactory factory,
        ICustomerReadService readService, IPhoneNumberService phoneService)
    {
        _repository = repository;
        _factory = factory;
        _readService = readService;
        _phoneService = phoneService;
    }

    public async Task HandleAsync(CreateCustomerCommand command)
    {
        var (id, firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber) = command;


        if (await _readService.ExistsByEmailAsync(email))
        {
            throw new CustomerEmailAlreadyExistsException(email);
        }

        if (await _readService.ExistsDuplicateAsync(firstname, lastname, dateOfBirth))
        {
            throw new CustomerAlreadyExistsException(firstname, lastname, dateOfBirth);
        }

        var error = await _phoneService.ValidatePhoneNumberAsync(phoneNumber);
        if (!string.IsNullOrEmpty(error))
        {
            throw new WrongPhoneNumberException(phoneNumber, error);
        }

        var customer = _factory.Create(id, firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);

        await _repository.AddAsync(customer);
    }

}

