using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; private set; }
        public int RoleId { get; private set; }
        public bool? IsActive { get; private set; }
        public int AssignedByUserId { get; private set; }
    
        //Navigation Property
        public User User { get; private set; } = null!;
        public Role Role { get; private set; } = null!;

        private UserRole() { }

        public UserRole(int userId, int roleId, int assignedByUserId)
        {
            if (userId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(userId),
                    "User ID must be greater than zero.");

            if (roleId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(roleId),
                    "Role ID must be greater than zero.");

            if (assignedByUserId <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(assignedByUserId),
                    "User ID for assignedbyuserId must be greater than zero.");

            UserId = userId;
            RoleId = roleId;
            IsActive = true;
            AssignedByUserId = assignedByUserId;

            MarkAsUpdated();
        }

        public void Deactivate()
        {
            IsActive = false;
            MarkAsUpdated();
        }

        public void Activate()
        {
            IsActive = true;
            MarkAsUpdated();
        }

    }
}
