namespace Transport_Time.Models
{
    public class GenericResponse<T>
    {
        public int StatusCode { get; set; }
        public T? Content { get; set; }
        public string? InnerException { get; set; }
    }
}
