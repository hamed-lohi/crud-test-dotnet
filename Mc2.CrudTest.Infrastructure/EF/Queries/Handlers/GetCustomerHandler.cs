
using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Application.Queries;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Mc2.CrudTest.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EF.Queries.Handlers;

internal sealed class GetCustomerHandler : IQueryHandler<GetCustomerQuery, CustomerDto>
{
    private readonly DbSet<CustomerReadModel> _customers;

    public GetCustomerHandler(ReadDbContext context)
        => _customers = context.Customers;

    public Task<CustomerDto?> HandleAsync(GetCustomerQuery query)
        => _customers
            .Where(pl => pl.Id == query.Id)
            .Select(p => p.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}
