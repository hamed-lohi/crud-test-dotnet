using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.Factories;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Factories;

public sealed class CustomerFactory : ICustomerFactory
{
    public Customer Create(CustomerId id, string firstname, string lastname, DateTime dateOfBirth,
        string phoneNumber, CustomerEmail email, CustomerBankAccountNumber bankAccountNumber)
    => new (id, firstname, lastname, dateOfBirth, phoneNumber, email, bankAccountNumber);
}