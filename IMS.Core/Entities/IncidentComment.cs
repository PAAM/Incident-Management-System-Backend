using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class IncidentComment : BaseEntity
    {
        public string IncidentNumber { get; private set; } = string.Empty; //FK
        public string Comment { get; private set; } = string.Empty;
        public int UserId { get; private set; } //FK

        //Navigation Property
        public User User { get; private set; } = null!;

        public Incident Incident { get; private set; } = null!;
        
        private IncidentComment() { }

        public IncidentComment(string incidentNumber,
            string comment,
            int userId)
        {
            if (string.IsNullOrWhiteSpace(incidentNumber))
                throw new ArgumentException(nameof(incidentNumber), "Incident number cannot be null.");

            if (string.IsNullOrWhiteSpace(comment))
                throw new ArgumentNullException(nameof(comment), "The comment cannot be null.");

            if (userId <= 0)
                throw new ArgumentOutOfRangeException(nameof(userId), "The User Id cannot be null.");

            IncidentNumber = incidentNumber;
            Comment = comment;
            UserId = userId;
        }

        public void UpdateDescription(string comment)
        {
            if (!string.IsNullOrWhiteSpace(comment))
            {
                Comment = comment;
                MarkAsUpdated();
            }
        }
    }
}
