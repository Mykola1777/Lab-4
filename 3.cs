using System;


public class Road
{
    public double Length { get; set; }
    public double Width { get; set; }
    public int Lanes { get; set; }
    public int TrafficLevel { get; set; }
}

public class Vehicle : IDriveable
{
    public int Speed { get; set; }
    public string Size { get; set; }
    public string VehicleType { get; set; }

    public void Move()
    {
        Console.WriteLine($"The {VehicleType} is moving at {Speed} km/h.");
    }

    public void Stop()
    {
        Console.WriteLine($"The {VehicleType} has stopped.");
    }
}

public interface IDriveable
{
    void Move();
    void Stop();
}

public class Simulation
{
    private Road road;
    private List<Vehicle> vehicles;

    public Simulation(Road road, List<Vehicle> vehicles)
    {
        this.road = road;
        this.vehicles = vehicles;
    }

    public void SimulateTraffic()
    {
        foreach (var vehicle in vehicles)
        {
            vehicle.Move();

            if (road.TrafficLevel > 3)
            {
                vehicle.Stop();
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Road road = new Road { Length = 1000, Width = 4, Lanes = 2, TrafficLevel = 5 };
        Vehicle car = new Vehicle { Speed = 60, Size = "compact", VehicleType = "car" };
        Vehicle truck = new Vehicle { Speed = 50, Size = "large", VehicleType = "truck" };

        List<Vehicle> vehicles = new List<Vehicle> { car, truck };
        Simulation simulation = new Simulation(road, vehicles);
        simulation.SimulateTraffic();
    }
}

