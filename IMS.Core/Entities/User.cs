using IMS.Core.Common;

namespace IMS.Core.Entities
{
    public class User : BaseEntity
    {
        public string EmployeCode { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string? SecondName { get; private set; }
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;

        //FK
        public int AreaId { get; private set; }
        public bool? IsActive { get; private set; }

        //Navigation property
        public Area Area { get; private set; } = null!;
        public ICollection<Incident> ReportedIncidents { get; private set; } = new List<Incident>();
        public ICollection<Incident> AssignedIncidents { get; private set; } = new List<Incident>();    
        public UserCredentials UserCredentials { get; private set; } = null!;

        private User()
        {
            //Required By EF
        }

        public User(string employecCode,
            string firstName,
            string? secondName,
            string lastName,
            string email,
            int areaId)
        {
            EmployeCode = employecCode;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            AreaId = areaId;
            IsActive = true;
        }

        public void UpdateEmail(string email)
        {
            Email = email;
            MarkAsUpdated();
        }

        public void Activate()
        {
            IsActive = true;
            MarkAsUpdated();
        }

        public void Deactivate()
        {
            IsActive = false;
            MarkAsUpdated();
        }

    }
}
