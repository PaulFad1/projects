using Microsoft.AspNetCore.SignalR.Client;
using BlazorServer.Hubs;
using BlazorServer.Data;
public class ConnectionService: BackgroundService 
{
    private ConnectHub connectHub;
    private List<Kzik_Info> kziks;
    protected override async Task ExecuteAsync(CancellationToken token)
    {
        
        while(!token.IsCancellationRequested)
        {
            try{
                    foreach(var kz in kziks)
                    {
                        await getMessage(kz.Name,kz.IP,kz.isRunning);
                    }
            }
            catch(Exception e)
            {}
            await Task.Delay(1000);
        }
    }
    public override async Task StartAsync(CancellationToken token)
    {
          kziks = new List<Kzik_Info>(){
            new Kzik_Info("Kzik 1", "192.168.1.1", false),
            new Kzik_Info("Kzik 2", "192.168.1.2", false),
            new Kzik_Info("Kzik 3", "192.168.1.3", false)
        };
        connectHub = new ConnectHub();
        await this.ExecuteAsync(token);
    }
    private async Task getMessage(string n, string i, bool r)
    {
        await connectHub.SendMessage(n,i,r);
    }
}