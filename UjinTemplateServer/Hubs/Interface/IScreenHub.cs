using UjinTemplateServer.Models;

namespace UjinTemplateServer.Hubs.Interface
{
    public interface IScreenHub
    {
        Task ScreenAuthentificate(ScreenDtoTo screen);
        //Task UpdateScreen(ScreenDtoTo screen);
    }
}
