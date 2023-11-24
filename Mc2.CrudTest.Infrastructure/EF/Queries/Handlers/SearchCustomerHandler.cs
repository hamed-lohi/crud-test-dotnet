using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Mc2.CrudTest.Shared.Abstraction.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EF.Queries.Handlers;

internal sealed class SearchCustomerHandler : IQueryHandler<SearchCustomerQuery, IEnumerable<CustomerDto>>
{
    private readonly DbSet<CustomerReadModel> _customers;

    public SearchCustomerHandler(ReadDbContext context)
        => _customers = context.Customers;

    public async Task<IEnumerable<CustomerDto>> HandleAsync(SearchCustomerQuery query)
    {
        var dbQuery = _customers.AsQueryable();

        if (query.SearchPhrase is not null)
        {
            dbQuery = dbQuery.Where(p =>
                Microsoft.EntityFrameworkCore.EF.Functions.Like(p.Firstname+p.Lastname, $"%{query.SearchPhrase}%"));
        }

        return await dbQuery
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .ToListAsync();
    }
}

