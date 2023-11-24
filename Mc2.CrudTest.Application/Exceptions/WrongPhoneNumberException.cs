using Mc2.CrudTest.Shared.Abstraction.Exceptions;

namespace Mc2.CrudTest.Application.Exceptions
{
    public class WrongPhoneNumberException : CustomerException
    {
        public string PhoneNumber { get; }
        public string ValidateMessage { get; }

        public WrongPhoneNumberException(string value, string validateMessage) : base($"The phone number '{value}' is wrong. {validateMessage}")
        {
            PhoneNumber = value;
            ValidateMessage = validateMessage;
        }
    }
}
