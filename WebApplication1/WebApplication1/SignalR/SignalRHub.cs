using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.SignalR
{
    public class SignalRHub:Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine(this.Context.ConnectionId);
            return base.OnConnectedAsync();
        }
    }
}
