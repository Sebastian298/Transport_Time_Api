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

        [HttpPost("AssignRouteToTruck")]
        public async Task<IActionResult> AssignRuteToTruck(InsertBusRute insertBusRute)
        {
            var response = await _transportRepository.AssignRuteToTruckAsync(insertBusRute);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetAssignedRoutes")]
        public async Task<IActionResult> GetAssignedRoutes()
        {
            var response = await _transportRepository.GetAssignedRoutesAsync();

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetDetailRouteByRouteId")]
        public async Task<IActionResult> GetDetailRouteByRouteId(string routeId)
        {
            var response = await _transportRepository.GetDetailRouteByRouteId(routeId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpDelete("RemoveTruckFromRoute")]
        public async Task<IActionResult> RemoveTruckFromRoute(string busId, string routeId)
        {
            var response = await _transportRepository.RemoveTruckFromRouteAsync(busId, routeId);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetInfoForCurrentRoute")]
        public async Task<IActionResult> GetInfoForCurrentRoute(string originCoordinates)
        {
            var response = await _transportRepository.GetInfoForCurrentRouteAsync(originCoordinates);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(InsertUser insertUser)
        {
            var response = await _transportRepository.CreateUserAsync(insertUser);

            return StatusCode(response.StatusCode, response);
        }

        [HttpPost("GetLogInUsers")]
        public async Task<IActionResult> GetLogInUsers(InsertUser insertUser)
        {
            var response = await _transportRepository.GetLogInUsersAsync(insertUser);

            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetRoutesWithCoordinates")]
        public async Task<IActionResult> GetRoutesWithCoordinates()
        {
            var response = await _transportRepository.GetRoutesWithCoordinates();

            return StatusCode(response.StatusCode, response);
        }
    }
}
