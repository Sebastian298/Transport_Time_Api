namespace Transport_Time.Models
{
    public class DapperServiceResponse
    {
        public bool HasError { get; set; }
        public string? InnerException { get; set; }
        public dynamic? Results { get; set; }
    }
}
