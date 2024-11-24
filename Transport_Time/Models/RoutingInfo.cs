namespace Transport_Time.Models
{
    public class RoutingInfo
    {
        public required Summary Summary { get; set; }
        public required List<Points> Points { get; set; }
    }
}
