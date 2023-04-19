using Microsoft.AspNetCore.SignalR;

namespace SW4BED_3.Hubs
{
    public class ChatHub : Hub
    {
        public async Task UpdatePage()
        {
            await Clients.All.SendAsync("Update");
        }
    }
}
