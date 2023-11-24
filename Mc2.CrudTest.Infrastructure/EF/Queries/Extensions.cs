using Mc2.CrudTest.Application.DTO;
using Mc2.CrudTest.Infrastructure.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Infrastructure.EF.Queries;

internal static class Extensions
{
    public static CustomerDto AsDto(this CustomerReadModel readModel)
        => new()
        {
            Id = readModel.Id,
            Firstname = readModel.Firstname,
            Lastname = readModel.Lastname,
            DateOfBirth = readModel.DateOfBirth,
            PhoneNumber = readModel.PhoneNumber,
            Email = readModel.Email,
            BankAccountNumber = readModel.BankAccountNumber,
        };
}
