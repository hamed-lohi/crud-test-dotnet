using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Shared.Abstractions.Queries;

namespace Mc2.CrudTest.Application.Queries;

public class SearchCustomerQuery : IQuery<IEnumerable<CustomerDto>>
{
    public string SearchPhrase { get; set; }
}
