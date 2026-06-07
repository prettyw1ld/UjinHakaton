using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using UjinTemplateServer.Models;

namespace UjinHakaton.Services
{
    public class ScreenService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<List<ScreenDto>?> GetScreensAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<ScreenDto>>(
                    "https://localhost:7271/screens");
        }

        public async Task<List<Template>?> GetTemplatesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Template>>(
                "https://localhost:7271/api/template");
        }

        public async Task SetTemplateAsync(Guid screenId, int templateId)
        {
            await _httpClient.PutAsync(
                $"https://localhost:7271/Screens/{screenId}/template/{templateId}",
                null);
        }
         
        public async Task<Bitmap> LoadBitmapAsync(string imageUrl)
        {
            var bytes = await _httpClient.GetByteArrayAsync(imageUrl);

            using var stream = new MemoryStream(bytes);

            return new Bitmap(stream);
        }

        public async Task ConfirmScreenAsync(ScreenDto screen)
        {
            var dto = new ScreenDtoFromServer(
                screen.Id,
                screen.DeviceCode,
                screen.BuildingId ?? 0,
                true
            );

            var response = await _httpClient.PostAsJsonAsync(
                "https://localhost:7271/Screens/confirm",
                screen.Id);

            response.EnsureSuccessStatusCode();
           
        }
    }
}
