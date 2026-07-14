using IMS.Core.Entities;
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
    public class RoleRepository: IRoleRepository
    {

        private readonly IMSDbContext _context;
        public RoleRepository(IMSDbContext context) 
        { 
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        { 
            var role = await _context.Roles.ToArrayAsync();
            return role;
        }
    }
}
