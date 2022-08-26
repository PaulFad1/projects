using Microsoft.AspNetCore.SignalR.Client;
using BlazorServer.Hubs;
using BlazorServer.Data;
using Microsoft.AspNetCore.SignalR;

public class ConnectionService: BackgroundService 
{
    private IHubContext<ConnectHub> connectHub;
    private List<Kzik_Info> kziks;

    public ConnectionService(IHubContext<ConnectHub> hub)
    {
        connectHub = hub;
    }
    protected override async Task ExecuteAsync(CancellationToken token)
    {
         kziks = new List<Kzik_Info>(){
            new Kzik_Info("Kzik 1", "192.168.1.1", false),
            new Kzik_Info("Kzik 2", "192.168.1.2", false),
            new Kzik_Info("Kzik 3", "192.168.1.3", false)
        };
        while(!token.IsCancellationRequested)
        {
            try{
            }
            catch(Exception e)
            {}
            await Task.Delay(1000);
        }
    }
    public async Task getMessage()
    {
        foreach(var kz in kziks)
        {
            await connectHub.Clients.All.SendAsync("Get",kz.Name,kz.IP,kz.isRunning);
        }
        
    }
}