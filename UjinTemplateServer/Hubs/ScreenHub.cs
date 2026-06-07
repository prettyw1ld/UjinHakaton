using Microsoft.AspNetCore.SignalR;
using UjinTemplateServer.Hubs.Interface;

namespace UjinTemplateServer.Hubs
{
    public class ScreenHub : Hub<IScreenHub>
    {
        public override async Task OnConnectedAsync()
        {
            var screenId =
                Context.GetHttpContext()?.Request.Query["screenId"];

            if (!string.IsNullOrEmpty(screenId))
            {
                await Groups.AddToGroupAsync(
                    Context.ConnectionId,
                    screenId);
            }

            await base.OnConnectedAsync();
        }
    }
}
