using IMS.Core.Entities;
using IMS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Infrastructure.Repositories
{
    public class IncidentRepository: IIncidentRepository
    {
        public async Task< IEnumerable<Incident>> GetIncidents() {
            var incident = Enumerable.Range(1, 10).Select(x => new Incident
            {
                IncidentId = x,
                Title = $"Incident Number{x}",
                Description = "Description Test",
                Priority = 1,
                Status = 1,
                CreatedBy = $"Pedro A {x}",
                AssignedTo = $"Pepito Perez {x}",
                CloseDate = DateTime.Now,
                CreationDate = DateTime.Now,
                LastUpdate = DateTime.Now
            });
            await Task.Delay(10);
            return incident;

        }
    }
}
