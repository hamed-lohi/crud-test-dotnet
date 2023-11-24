using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands.Handlers;

public sealed class UpdateCustomerHandler : ICommandHandler<UpdateCustomerCommand>
{
    private readonly ICustomerRepository _repository;

    public UpdateCustomerHandler(ICustomerRepository repository)
        => _repository = repository;

    public async Task HandleAsync(UpdateCustomerCommand command)
    {
        var customer = await _repository.GetAsync(command.CustomerId);

        if (customer is null)
        {
            throw new CustomerNotFoundException(command.CustomerId);
        }

        customer.SetBankAccountNumber(command.BankAccountNumber);

        await _repository.UpdateAsync(customer);
    }
}
