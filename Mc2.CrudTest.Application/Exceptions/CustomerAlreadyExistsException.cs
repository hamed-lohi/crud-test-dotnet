using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Application.Exceptions;

public class CustomerAlreadyExistsException : CustomerException
{
    public string Firstname { get; }
    public string Lastname { get; }
    public DateTime DateOfBirth { get; }

    public CustomerAlreadyExistsException(string firstName, string lastName, DateTime dateOfBirth)
        : base($"Customer with this info '{firstName}, {lastName}, {dateOfBirth}' already exists.")
    {
        Firstname = firstName;
        Lastname = lastName;
        DateOfBirth = dateOfBirth;
    }
}
