using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class UserCredentials : BaseEntity
    {
        //FK
        public int UserId { get; private set; }
        public string PasswordHash { get; private set; } = string.Empty;
        public bool IsLocked { get; private set; }
        public int FailedLoginAttempts { get; private set; }
        public DateTimeOffset? LastLoginAt { get; private set; } = null;

        //Navigation Property
        public User User { get; private set; } = null!;

        private UserCredentials() { }

        public UserCredentials(int userId, string passwordHash)
        {
            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password hash cannot be empty.", nameof(passwordHash));

            UserId = userId;
            PasswordHash = passwordHash;
            IsLocked = false;
            FailedLoginAttempts = 0;
        }

        private const int MaxFailedLoginAttempts = 3;
        public void RegisterFailedLogin()
        {
            FailedLoginAttempts++;
            if (FailedLoginAttempts >= MaxFailedLoginAttempts)
            {
                IsLocked = true;
            }
            MarkAsUpdated();
        }

        public void RegisterSuccessfulLogin()
        {
            FailedLoginAttempts = 0;
            LastLoginAt = DateTimeOffset.Now;
            MarkAsUpdated();
        }
        public void ChangePassword(string newPasswordHash)
        {
            PasswordHash = newPasswordHash;
            MarkAsUpdated();
        }
        public void Unlock()
        {
            IsLocked = false;
            MarkAsUpdated();
        }
    }
}
