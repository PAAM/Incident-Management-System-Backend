using IMS.Core.Dtos;
using IMS.Core.Interfaces;
using IMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMSDbContext _context;
        public UserRepository( IMSDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<UserByRoleDto>> GetUsersByRoleAsync(int roleId)
        {
            return await _context.UserRoles
                .Where(ur => ur.RoleId == roleId)
                .Select(ur => new UserByRoleDto
                {
                    EmployeeCode = ur.User.EmployeCode,
                    FullName = $"{ur.User.FirstName} {ur.User.LastName}",
                    Email = ur.User.Email,
                }).ToArrayAsync();

            throw new NotImplementedException();
        }
    }
}
