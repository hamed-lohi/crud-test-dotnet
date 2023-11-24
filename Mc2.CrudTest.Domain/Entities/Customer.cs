using Mc2.CrudTest.Domain.ValueObjects;
using Mc2.CrudTest.Shared.Abstraction.Domain;

namespace Mc2.CrudTest.Domain.Entities;

public class Customer: AggregateRoot<CustomerId>
{
    private string _firstname;
    private string _lastname;
    private DateTime _dateOfBirth;
    private string _phoneNumber;
    private CustomerEmail _email;
    private CustomerBankAccountNumber _bankAccountNumber;

    public Customer()
    {
    }

    internal Customer(CustomerId id, string firstname, string lastname, DateTime dateOfBirth, string phoneNumber,
            CustomerEmail email, CustomerBankAccountNumber bankAccountNumber)
    {
        Id = id;
        _firstname = firstname;
        _lastname = lastname;
        _phoneNumber = phoneNumber;
        _email = email;
        _bankAccountNumber = bankAccountNumber;
    }

    public void SetBankAccountNumber(CustomerBankAccountNumber bankAccountNumber)
    {
        _bankAccountNumber = bankAccountNumber;
    }
}
