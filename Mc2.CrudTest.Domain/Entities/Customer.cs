using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Domain;

namespace Mc2.CrudTest.Domain.Entities;

public class Customer: AggregateRoot<CustomerId>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string PhoneNumber { get; set; }
    public CustomerEmail Email { get; set; }
    public CustomerBankAccountNumber BankAccountNumber { get; set; }

    public Customer()
    {
    }


}
