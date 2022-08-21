namespace BlazorServer.Data
{
public class Kzik_Info
{
    public string Name {get;set;}
    public string IP {get;set;}
    public bool isRunning {get;set;}

    public Kzik_Info(string n, string i, bool r)
    {
        Name = n;
        IP = i;
        isRunning = r;
    }

    public string getStatusString()
    {
        if(isRunning == true)
        {
            return "Running";
        }
        else
        {
            return "Disconnecting";
        }
    }
}
}