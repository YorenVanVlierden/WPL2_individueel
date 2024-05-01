using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MauiAppTeam14.Services
{
    public class RestService
    {
        private const string REST_URL = "https://mc73snvd-7091.euw.devtunnels.ms/api/";  // Base URL for Web API
        private static readonly HttpClient httpClient = new HttpClient();  // Shared HttpClient instance
        private readonly string baseUrl;

        public RestService(string baseUrl = REST_URL)
        {
            this.baseUrl = baseUrl;  // Set the base URL
        }

        // Method to fetch data from the Web API and deserialize it
        public async Task<T> GetDeserializedAsync<T>(string endpoint)
        {
            var fullUrl = $"{baseUrl}{endpoint}";  // Construct the full URL using baseUrl and endpoint
            var response = await httpClient.GetAsync(fullUrl);  // Perform the GET request
            response.EnsureSuccessStatusCode();  // Ensure success

            var content = await response.Content.ReadAsStringAsync();  // Read the response content
            return JsonConvert.DeserializeObject<T>(content);  // Deserialize the JSON content
        }
    }
}
