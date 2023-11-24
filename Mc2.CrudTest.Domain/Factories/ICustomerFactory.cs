using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Domain.ValueObjects;

namespace Mc2.CrudTest.Domain.Factories;

public interface ICustomerFactory
{
    Customer Create(CustomerId id, string firstname, string lastname, 
        DateTime dateOfBirth, string phoneNumber, CustomerEmail email, CustomerBankAccountNumber bankAccountNumber);
}
