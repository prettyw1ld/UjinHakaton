using System.Net.Http;
using System.Threading.Tasks;
using UjinHakaton.Interfaces;
using UjinHakaton.Models.API;

namespace UjinHakaton.Service
{
    public class NewsService(HttpClient httpClient) : ApiBase(httpClient), INewsService
    {
        public Task<NewsListResponse?> GetNewsAsync()
        {
            return GetAsync<NewsListResponse>("api/v1/news/list");
        }
    }
}
