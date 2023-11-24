using Mc2.CrudTest.Domain.Exceptions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerBankAccountNumber
{
    public string Value { get; }

    public CustomerBankAccountNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !ValidateBankAccountNumber(value))
        {
            throw new InvalidBankAccountNumberException(value);
        }

        Value = value.Trim();
    }


    public static implicit operator string(CustomerBankAccountNumber phoneNumber)
        => phoneNumber.Value;

    public static implicit operator CustomerBankAccountNumber(string phoneNumber)
        => new(phoneNumber);

    private static bool ValidateBankAccountNumber(string accountNumber)
    {
        // Example validation: Check if the account number has 9 digits
        return accountNumber.Length == 9;
    }
}
