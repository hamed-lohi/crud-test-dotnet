using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services;

public interface ICustomerReadService
{
    Task<bool> ExistsByEmailAsync(string name);
    Task<bool> ExistsDuplicateAsync(string firstname, string lastname, DateTime dateOfBirth);
}
