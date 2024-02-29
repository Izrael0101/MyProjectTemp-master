using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyProjectTemp.MVC.Models; // Asegúrate de usar el espacio de nombres correcto para ApiResponse<T>

namespace MyProjectTemp.MVC.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<T>>(responseBody);
            if (apiResponse.Success)
            {
                return apiResponse.Result;
            }
            else
            {
                throw new ApplicationException(apiResponse.Message);
            }
        }

        public async Task<TResponse> PostAsync<TRequest, TResponse>(string uri, TRequest data)
        {
            string content = JsonConvert.SerializeObject(data);
            var response = await _httpClient.PostAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseBody);
            if (apiResponse.Success)
            {
                return apiResponse.Result;
            }
            else
            {
                throw new ApplicationException(apiResponse.Message);
            }
        }

        public async Task<TResponse> PutAsync<TRequest, TResponse>(string uri, TRequest data)
        {
            string content = JsonConvert.SerializeObject(data);
            var response = await _httpClient.PutAsync(uri, new StringContent(content, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseBody);
            if (apiResponse.Success)
            {
                return apiResponse.Result;
            }
            else
            {
                throw new ApplicationException(apiResponse.Message);
            }
        }

        public async Task DeleteAsync(string uri)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse<object>>(responseBody);
            if (!apiResponse.Success)
            {
                throw new ApplicationException(apiResponse.Message);
            }
        }
    }
}