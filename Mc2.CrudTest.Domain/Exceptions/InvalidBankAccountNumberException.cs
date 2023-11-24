using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class InvalidBankAccountNumberException : CustomerException
{
    public string BankAccountNumber { get; }

    public InvalidBankAccountNumberException(string value) : base($"'{value}' is invalid bank account number.")
    {
        BankAccountNumber = value;
    }
}
