namespace Transport_Time.Models
{
    public class HttpServiceResponse<T>
    {
        public bool Success { get; set; }
        public T? Content { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
