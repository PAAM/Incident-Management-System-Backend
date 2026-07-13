using IMS.Core.Interfaces;
using IMS.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Api.Controllers
{
    [Route("api/Incident")]
    [ApiController]
    public class IncidentController : ControllerBase
    {
        private readonly IIncidentRepository _incidentRepository;
        public IncidentController(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }

        [HttpGet]   
        public async Task<IActionResult> GetIncidents()
        {
            var incident = await _incidentRepository.GetIncidents();
            return Ok(incident);
        }
    }
}
