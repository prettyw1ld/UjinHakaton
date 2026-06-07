using Microsoft.AspNetCore.SignalR;
using UjinTemplateServer.Hubs.Interface;

namespace UjinTemplateServer.Hubs
{
    public class ScreenHub : Hub<IScreenHub>
    {
        public override async Task OnConnectedAsync()
        {
            var id =
                Context.GetHttpContext()?.Request.Query["id"];

            if (!string.IsNullOrEmpty(id))
            {
                await Groups.AddToGroupAsync(
                    Context.ConnectionId,
                    id);
            }

            await base.OnConnectedAsync();
        }
    }
}
