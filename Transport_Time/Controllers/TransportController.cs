using Microsoft.AspNetCore.Mvc;
using Transport_Time.Models;
using Transport_Time.Repositories;

namespace Transport_Time.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransportController : ControllerBase
    {
        private readonly ITransportRepository _transportRepository;

        public TransportController(ITransportRepository transportRepository)
        {
            _transportRepository = transportRepository;
        }

        [HttpGet("GetUnnasignedTrucks")]
        public async Task<IActionResult> GetUnnasignedTrucks()
        {
            var response = await _transportRepository.GetUnnasignedTrucks();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetUnnasignedRoutes")]
        public async Task<IActionResult> GetUnnasignedRoutes()
        {
            var response = await _transportRepository.GetUnnasignedRoutes();

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("AssignRuteToTruck")]
        public async Task<IActionResult> AssignRuteToTruck(InsertBusRute insertBusRute)
        {
            var response = await _transportRepository.AssignRuteToTruckAsync(insertBusRute);

            return StatusCode(response.StatusCode, response);
        }
    }
}
