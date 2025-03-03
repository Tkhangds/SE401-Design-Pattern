using System;

abstract class Logistics
{
    public abstract Transport CreateTransport();
    
    public void SomeMethod()
    {
        Transport transport = CreateTransport();
        Console.WriteLine($"Using transport: {transport.Deliver()}");
    }
}

class RoadLogistics : Logistics
{
    public override Transport CreateTransport()
    {
        return new Truck();
    }
}

class SeaLogistics : Logistics
{
    public override Transport CreateTransport()
    {
        return new Ship();
    }
}
interface Transport
{
    string Deliver();
}

class Truck : Transport
{
    public string Deliver()
    {
        return "Deliver On Road!";
    }
}
class Ship : Transport
{
    public string Deliver()
    {
        return "Deliver On Ship!";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Road Logistics:");
        Logistics roadLogistics = new RoadLogistics();
        roadLogistics.SomeMethod();
        
        Console.WriteLine("\nSea Logistics:");
        Logistics seaLogistics = new SeaLogistics();
        seaLogistics.SomeMethod();
    }
}