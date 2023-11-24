

namespace Mc2.CrudTest.Application.Services;

public interface IPhoneNumberService
{
    Task<string?> ValidatePhoneNumberAsync(string phoneNumber);
}
