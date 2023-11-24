using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Domain.Exceptions;

public class InvalidEmailException : CustomerException
{
    public string Email { get; }

    public InvalidEmailException(string value) : base($"'{value}' is invalid email.")
    { 
        Email = value;
    }
}
