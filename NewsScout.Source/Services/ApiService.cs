﻿using System.Net.Http.Json;

namespace NewsScout.Services
{
    public class ApiService
    {

        #region Properties

        public string CustomQuery { get; set; }

        #endregion

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

        // Request with Country and Language / Optional Search
        public static async Task<ApiResponse> GetNewsWithSettingsAndSearch(string? _searchString = null)
        {
            Settings _settings = ConfigurationService.LoadSettings();
            ApiResponse? _returnResponse = new ApiResponse();
            StringBuilder _query = new StringBuilder($"https://newsdata.io/api/1/news?apikey={_settings.ApiKey}");

            if (_settings.Country != null)
            {
                _query.Append("&country=");
                foreach (string _countryCode in _settings.Country)
                {
                    _query.Append(_countryCode + ',');
                }
                _query.Length--;
            }

            if (_settings.Language != null)
            {
                _query.Append("&language=");
                foreach (string _languageCode in _settings.Language)
                {
                    _query.Append(_languageCode + ',');
                }
                _query.Length--;
            }

            if (_searchString != null)
            {
                _query.Append("&q=" + _searchString);
            }

            using (HttpClient _client = new HttpClient())
            {
                HttpRequestMessage _request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_query.ToString())
                };

                using (HttpResponseMessage _response = await _client.SendAsync(_request))
                {
                    _response.EnsureSuccessStatusCode();
                    return _returnResponse = await _response.Content.ReadFromJsonAsync<ApiResponse>();
                }
            }
        }

        // Convert custom search string to URL friendly version
        public static string ConvertSearchForURL(string _searchQuery)
        {
            StringBuilder _returnString = new StringBuilder();
            _searchQuery = _searchQuery.Trim();

            // Spaces
            string _urlSpace = "%20";
            string[] _wordArray = _searchQuery.Split(' ');

            foreach (string _word in _wordArray)
            {
                _returnString.Append(_word + _urlSpace);
            }
            _returnString.Length = _returnString.Length - 3;

            return _returnString.ToString();
        }

        #endregion

    }
}
