using Microsoft.AspNetCore.SignalR;
namespace BlazorServer.Hubs
{
    public class ConnectHub: Hub
    {
        public async Task SendMessage(string n ,  string i, bool r)
        {
            await Clients.All.SendAsync("Get",n,i,r);
        }
    }

}