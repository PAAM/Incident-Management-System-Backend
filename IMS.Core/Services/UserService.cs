using IMS.Core.Dtos;
using IMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IReadOnlyList<UserByRoleDto>> GetUsersByRoleAsync(int rolId)
        {
            return await _userRepository.GetUsersByRoleAsync(rolId);            
        }
    }
}
