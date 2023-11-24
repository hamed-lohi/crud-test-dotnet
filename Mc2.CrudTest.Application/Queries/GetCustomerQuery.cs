using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Shared.Abstractions.Queries;

namespace Mc2.CrudTest.Application.Queries;

public class GetCustomerQuery : IQuery<CustomerDto>
{
    public Guid Id { get; set; }
}
