namespace abstract_factory_sample;

abstract class Logistics
{
    public abstract Transport CreateTransport();
    public abstract Employee CreateEmployee();
    public void SomeMethod()
    {
        Transport transport = CreateTransport();
        Employee employee = CreateEmployee();
        Console.WriteLine(employee.Work() + $"\nUsing transport: {transport.Deliver()}");
    }
}

class RoadLogistics : Logistics
{
    public override Transport CreateTransport()
    {
        return new Truck();
    }

    public override Employee CreateEmployee()
    {
        return new Driver();
    }
}

class SeaLogistics : Logistics
{
    public override Transport CreateTransport()
    {
        return new Ship();
    }
    
    public override Employee CreateEmployee()
    {
        return new Sailor();
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

interface Employee
{
    string Work();
}

class Driver : Employee
{
    public string Work()
    {
        return "We driver Drive!";
    }
}

class Sailor : Employee
{
    public string Work()
    {
        return "We sailor Sail!";
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