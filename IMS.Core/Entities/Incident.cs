namespace IMS.Core.Entities
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Status { get; set; }
        public string AssignedTo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime CloseDate { get; set; }        
        public DateTime LastUpdate { get; set; }
    }
}
