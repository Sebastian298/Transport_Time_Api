namespace Transport_Time.Models
{
    public class RoutingResponse
    {
        public required List<Routes> Routes { get; set; }
    }

    public class Routes
    {
        public required Summary Summary { get; set; }
        public required List<Legs> Legs { get; set; }
    }

    public class Legs
    {
        public required List <Points> Points { get; set; }
    }

    public class Summary
    {
        public float LengthInMeters { get; set; }
        public int TravelTimeInSeconds { get; set; }
        public int TrafficDelayInSeconds { get; set; }
        public int TrafficLengthInMeters { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }

    public class Points
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
