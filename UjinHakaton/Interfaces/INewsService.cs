using System.Threading.Tasks;
using UjinHakaton.Models.API;

namespace UjinHakaton.Interfaces
{
    public interface INewsService
    {
        Task<NewsListResponse?> GetNewsAsync();
    }
}
