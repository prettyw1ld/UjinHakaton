using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace UjinHakaton.Service
{
    public abstract class ApiBase(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string token = "ust-2814998-5e10d9ddc0e99d7c87380a1f2885c28a";

        protected async Task<T?> GetAsync<T>(string path)
        {
            var url = $"{path}?token={Uri.EscapeDataString(token)}";
            return await _httpClient.GetFromJsonAsync<T>(url);
        }
    }
}
