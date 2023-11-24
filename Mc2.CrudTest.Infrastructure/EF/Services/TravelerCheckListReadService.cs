using Mc2.CrudTest.Application.Services;
using Mc2.CrudTest.Infrastructure.EF.Contexts;
using Mc2.CrudTest.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Infrastructure.EF.Services;

internal sealed class CustomerReadService : ICustomerReadService
{
    private readonly DbSet<CustomerReadModel> _customerDbset;

    public CustomerReadService(ReadDbContext context)
        => _customerDbset = context.Customers;

    public Task<bool> ExistsByEmailAsync(string email)
        => _customerDbset.AnyAsync(p => p.Email == email);

    public Task<bool> ExistsDuplicateAsync(string firstname, string lastname, DateTime dateOfBirth)
        => _customerDbset.AnyAsync(p => p.Firstname == firstname && p.Lastname == lastname && p.DateOfBirth == dateOfBirth);
}
