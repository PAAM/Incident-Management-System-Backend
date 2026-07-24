using IMS.Core.Common;

namespace IMS.Core.Entities
{
    public class Incident : BaseEntity
    {
        public string IncidentNumber { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int PriorityId { get; private set; } //FK
        public int StatusId { get; private set; }  //FK
        public int AreaId { get; private set; }  //FK
        public int ReportedByUserId { get; private set; }  //FK
        public int? AssignedToUserId { get; private set; }  //FK

        //Navigation Property

        public Priority Priority { get; private set; } = null!;
        public Status Status { get; private set; } = null!;
        public Area Area { get; private set; } = null!;
        public User ReportedByUser { get; private set; } = null!;
        public User? AssignedToUser { get; private set; } = null!;
        public ICollection<IncidentComment> IncidentComments { get; private set; } = new List<IncidentComment>();

        private Incident() { }

        public Incident(string incidentNumber,
            string title,
            string description,
            int priorityId,
            int statusId,
            int areaId,
            int reportedByUserId)
        {
            if (string.IsNullOrWhiteSpace(incidentNumber))
                throw new ArgumentNullException(nameof(incidentNumber), "Incident number cannot be empty.");

            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title is required.", nameof(title));

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.", nameof(description));

            if (priorityId <= 0)
                throw new ArgumentException("Priority is required.", nameof(priorityId));

            IncidentNumber = incidentNumber;
            Title = title;
            Description = description;
            PriorityId = priorityId;
            StatusId = statusId;
            AreaId = areaId;
            ReportedByUserId = reportedByUserId;
        }


        public void AssignToUser(int assignedToUserId)
        {
            if (assignedToUserId <= 0)
                throw new ArgumentException("Assigned user is required.", nameof(assignedToUserId));

            AssignedToUserId = assignedToUserId;
            MarkAsUpdated();
        }


        public void ChangePriority(int priorityId)
        {
            if (priorityId <= 0)
                throw new ArgumentException("Priority Id is required.", nameof(priorityId));

            PriorityId = priorityId;
            MarkAsUpdated();
        }

        public void ChangeStatus(int statusId)
        {
            if (PriorityId <= 0)
                throw new ArgumentException("Status Id is required.", nameof(statusId));

            StatusId = statusId;
            MarkAsUpdated();
        }

        public void UpdateTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("The Title cannot be empty.", nameof(title));

            Title = title;
            MarkAsUpdated();
        }

        public void UpdateDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("The description cannot be empty.", nameof(description));

            Description = description;
            MarkAsUpdated();
        }
    }
}
