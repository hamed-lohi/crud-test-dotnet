using Mc2.CrudTest.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Domain.ValueObjects;

public record CustomerEmail
{
    public string Value { get; }

    public CustomerEmail(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || !ValidateEmail(value))
        {
            throw new InvalidEmailException(value);
        }

        Value = value.Trim();
    }


    public static implicit operator string(CustomerEmail phoneNumber)
        => phoneNumber.Value;

    public static implicit operator CustomerEmail(string phoneNumber)
        => new(phoneNumber);

    private static bool ValidateEmail(string email)
    {
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }
}
