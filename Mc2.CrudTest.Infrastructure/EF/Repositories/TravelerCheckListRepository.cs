using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Repositories;
using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EF.Repositories;

internal sealed class CustomerRepository : ICustomerRepository
{
    private readonly DbSet<Customer> _customers;
    private readonly WriteDbContext _writeDbContext;

    public CustomerRepository(WriteDbContext writeDbContext)
    {
        _customers = writeDbContext.Customers;
        _writeDbContext = writeDbContext;
    }

    public Task<Customer?> GetAsync(CustomerId id)
        => _customers.SingleOrDefaultAsync(p => p.Id == id);

    public async Task AddAsync(Customer customer)
    {
        await _customers.AddAsync(customer);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        _customers.Update(customer);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Customer customer)
    {
        _customers.Remove(customer);
        await _writeDbContext.SaveChangesAsync();
    }
}
