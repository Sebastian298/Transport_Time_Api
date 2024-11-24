namespace Transport_Time.Models
{
    public class CrudResponse
    {
        public bool Success { get; set; }
        public required string Message { get; set; }
        public string? InnerException { get; set; }
    }
}
