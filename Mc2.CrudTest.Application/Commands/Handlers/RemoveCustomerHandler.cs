using Mc2.CrudTest.Application.Exceptions;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands.Handlers;

public sealed class RemoveCustomerHandler : ICommandHandler<RemoveCustomerCommand>
{
    private readonly ICustomerRepository _repository;

    public RemoveCustomerHandler(ICustomerRepository repository)
        => _repository = repository;

    public async Task HandleAsync(RemoveCustomerCommand command)
    {
        var TravelerCheckList = await _repository.GetAsync(command.Id);

        if (TravelerCheckList is null)
        {
            throw new CustomerNotFoundException(command.Id);
        }

        await _repository.DeleteAsync(TravelerCheckList);
    }
}
