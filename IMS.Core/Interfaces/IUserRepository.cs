using IMS.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IReadOnlyList<UserByRoleDto>> GetUsersByRoleAsync(int roleId);
    }
}
