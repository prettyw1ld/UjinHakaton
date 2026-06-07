using Microsoft.EntityFrameworkCore;
using UjinTemplateServer.Models;

namespace UjinTemplateServer.Common
{
    public class HelperService(AppDbContext dbContext)
    {
        private readonly AppDbContext _dbContext = dbContext;
        private readonly HttpClient _httpClient = new HttpClient()
        {
            BaseAddress = new Uri("https://api-uae-test.ujin.tech/")
        };

        public async Task SyncBuildingsAsync()
        {
            var response =
                await _httpClient.GetFromJsonAsync<UjinBuildingsResponse>(
                    "api/v1/buildings/get-list-crm/?token=ust-2814998-5e10d9ddc0e99d7c87380a1f2885c28a");

            foreach (var item in response.Data.Buildings)
            {
                var complex = await _dbContext.Complexes
                    .FindAsync(item.Complex.Id);

                if (complex == null)
                {
                    complex = new Complex
                    {
                        Id = item.Complex.Id,
                        Title = item.Complex.Title
                    };

                    _dbContext.Complexes.Add(complex);
                }

                var buildingExists = await _dbContext.Buildings
                    .AnyAsync(x => x.Id == item.Building.Id);

                if (!buildingExists)
                {
                    _dbContext.Buildings.Add(new Building
                    {
                        Id = item.Building.Id,
                        Title = item.Building.Title,
                        ComplexId = complex.Id
                    });
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
