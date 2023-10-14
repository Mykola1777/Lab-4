using System;


public class Computer
{
    public string IPAddress { get; set; }
    public int Power { get; set; }
    public string OSType { get; set; }
}

public class Server : Computer, IConnectable
{
    public int StorageCapacity { get; set; }

    public void Connect(Computer device)
    {
        Console.WriteLine($"Server with IP {IPAddress} is connecting to {device.IPAddress}");
    }

    public void Disconnect(Computer device)
    {
        Console.WriteLine($"Server with IP {IPAddress} is disconnecting from {device.IPAddress}");
    }

    public void TransferData(string data)
    {
        Console.WriteLine($"Server with IP {IPAddress} is transferring data: {data}");
    }
}

public class Workstation : Computer, IConnectable
{
    public int UserCount { get; set; }

    public void Connect(Computer device)
    {
        Console.WriteLine($"Workstation with IP {IPAddress} is connecting to {device.IPAddress}");
    }

    public void Disconnect(Computer device)
    {
        Console.WriteLine($"Workstation with IP {IPAddress} is disconnecting from {device.IPAddress}");
    }

    public void TransferData(string data)
    {
        Console.WriteLine($"Workstation with IP {IPAddress} is transferring data: {data}");
    }
}

public class Router : Computer, IConnectable
{
    public int Bandwidth { get; set; }

    public void Connect(Computer device)
    {
        Console.WriteLine($"Router with IP {IPAddress} is connecting to {device.IPAddress}");
    }

    public void Disconnect(Computer device)
    {
        Console.WriteLine($"Router with IP {IPAddress} is disconnecting from {device.IPAddress}");
    }

    public void TransferData(string data)
    {
        Console.WriteLine($"Router with IP {IPAddress} is transferring data: {data}");
    }
}

public interface IConnectable
{
    void Connect(Computer device);
    void Disconnect(Computer device);
    void TransferData(string data);
}

class Program
{
    static void Main(string[] args)
    {
        Server server1 = new Server { IPAddress = "192.168.1.1", Power = 1000, OSType = "Windows", StorageCapacity = 2000 };
        Workstation workstation1 = new Workstation { IPAddress = "192.168.1.2", Power = 500, OSType = "Linux", UserCount = 5 };
        Router router1 = new Router { IPAddress = "192.168.1.3", Power = 300, OSType = "RouterOS", Bandwidth = 100 };

        server1.Connect(workstation1);
        server1.TransferData("Data from server to workstation");
        server1.Disconnect(workstation1);

        workstation1.Connect(router1);
        workstation1.TransferData("Data from workstation to router");
        workstation1.Disconnect(router1);

        router1.Connect(server1);
        router1.TransferData("Data from router to server");
        router1.Disconnect(server1);
    }
}
