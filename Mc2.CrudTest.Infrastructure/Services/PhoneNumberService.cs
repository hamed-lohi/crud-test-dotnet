using Mc2.CrudTest.Application.Services;
using PhoneNumbers;

namespace Mc2.CrudTest.Infrastructure.Services;

public sealed class PhoneNumberService : IPhoneNumberService
{

    public Task<string?> ValidatePhoneNumberAsync(string phoneNumber)
    {

        try
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            PhoneNumber swissNumberProto = phoneNumberUtil.Parse(phoneNumber, "US");
        }
        catch (NumberParseException e)
        {
            return Task.FromResult(e.Message);
        }
        return Task.FromResult(string.Empty);
    }
}
