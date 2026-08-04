using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Dtos
{
    public class UserByRoleDto
    {
        public string EmployeeCode { get; init; } = string.Empty;

        public string FullName { get; init; } = string.Empty;

        public string Email { get; init; } = string.Empty;
    }
}
