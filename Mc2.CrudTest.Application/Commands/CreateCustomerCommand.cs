using Mc2.CrudTest.Shared.Abstraction.Commands;

namespace Mc2.CrudTest.Application.Commands;

public record CreateCustomerCommand(Guid Id, string Firstname, string Lastname, DateTime DateOfBirth, string PhoneNumber,
   string Email, string BankAccountNumber) : ICommand;

