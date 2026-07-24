using IMS.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Core.Entities
{
    public class Status : BaseEntity
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }

        //Navigation Property
        public ICollection<Incident> Incidents { get; private set; } = new List<Incident>();


        public Status() { }

        public Status(string name, string description)
        {
            Name = name;
            Description = description;
            IsActive = true;
        }
    }
}
