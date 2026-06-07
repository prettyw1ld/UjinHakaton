using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UjinTemplateServer.Models;

namespace UjinHakaton.Services
{
    public class ScreenService
    {
        private readonly HttpClient _httpClient;

        public ScreenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ScreenDto>?> GetScreensAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<ScreenDto>>(
                    "https://localhost:7271/sreens");
        }
    }
}
