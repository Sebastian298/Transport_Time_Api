using System.Text.Json;
using Transport_Time.Models;

namespace Transport_Time.Services
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HttpServiceResponse<T>> GetAsync<T>(string url, Dictionary<string, string>? headers = null)
        {
            try
            {
                AddHeaders(headers);

                var response = await _httpClient.GetAsync(url);

                var content = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return new HttpServiceResponse<T>
                {
                    Success = response.IsSuccessStatusCode,
                    Content = response.IsSuccessStatusCode ? data : default,
                    ErrorMessage = response.IsSuccessStatusCode ? null : content
                };
            }
            catch (Exception ex)
            {
                return new HttpServiceResponse<T>
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        private void AddHeaders(Dictionary<string, string>? headers)
        {
            _httpClient.DefaultRequestHeaders.Clear();

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    _httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
        }
    }
}
