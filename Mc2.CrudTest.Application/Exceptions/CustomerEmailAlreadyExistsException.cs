using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerEmailAlreadyExistsException : CustomerException
{
    public string Email { get; }

    public CustomerEmailAlreadyExistsException(string email)
        : base($"Customer with email '{email}' already exists.")
    {
        Email = email;
    }
}
