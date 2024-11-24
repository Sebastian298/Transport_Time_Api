using Transport_Time.Models;

namespace Transport_Time.Services
{
    public class RoutingService
    {
        private readonly HttpService _httpService;
        private readonly IConfiguration _configuration;

        public RoutingService(HttpService httpService,IConfiguration configuration)
        {
            _httpService = httpService;
            _configuration = configuration;
        }

        public async Task<HttpServiceResponse<RoutingResponse>> CalculateRouteAsync(string coordinatesOrigin)
        {
            try
            {
                var tomtomApiKey = _configuration["tomtomApiKey"];
                var destinationCoordinates = _configuration["destinationPoint:coordinates"];
                var url = $"https://api.tomtom.com/routing/1/calculateRoute/{coordinatesOrigin}:{destinationCoordinates}/json?key={tomtomApiKey}&travelMode=bus&vehicleCommercial=true&routeType=fastest&avoid=unpavedRoads&traffic=true&vehicleLength=12&vehicleWidth=2.5&vehicleHeight=3.5&vehicleWeight=15000";
                var response = await _httpService.GetAsync<RoutingResponse>(url);
                return response;
            }
            catch (Exception ex)
            {
                return new HttpServiceResponse<RoutingResponse>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
