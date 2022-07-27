using System.Net.Http.Json;

namespace NewsScout.Services
{
    public class ApiService
    {

        #region Methods

        // General Request
        public static async Task<ApiResponse> GetNews()
        {
            Settings _settings = ConfigurationService.LoadSettings();
            ApiResponse? _returnResponse = new ApiResponse();

            using (HttpClient _client = new HttpClient())
            {
                HttpRequestMessage _request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://newsdata.io/api/1/news?apikey={_settings.ApiKey}")
                };

                using (HttpResponseMessage _response = await _client.SendAsync(_request))
                {
                    _response.EnsureSuccessStatusCode();
                    return _returnResponse = await _response.Content.ReadFromJsonAsync<ApiResponse>();
                }
            }
        }

        #endregion

    }
}
