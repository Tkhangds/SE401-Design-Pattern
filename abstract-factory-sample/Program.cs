namespace abstract_factory_sample;

abstract class CarFactory
{
    public abstract Car CreateSedanCar();
    public abstract Car CreateSUVCar();
    public abstract Car CreateElectricCar();
}


class USFactory : CarFactory
{
    public override Car CreateSedanCar()
    {
        return new USSedanCar();
    }

    public override Car CreateSUVCar()
    {
        return new USSUVCar();
    }

    public override Car CreateElectricCar()
    {
        return new USElectricCar();
    }
}

class ASIAFactory : CarFactory
{
    public override Car CreateSedanCar()
    {
        return new ASIASedanCar();
    }

    public override Car CreateSUVCar()
    {
        return new ASIASUVCar();
    }

    public override Car CreateElectricCar()
    {
        return new ASIAElectricCar();
    }
}

abstract class Car
{
    public string Enigne;
    public string Seat;
    public string Size;
    
    public string GetInfo()
    {
        return $"Engine: {Enigne}, Seat: {Seat}, Size: {Size}";
    }
}

class SedanCar : Car
{
    public SedanCar()
    {
        Enigne = "1.6L";
        Seat = "4";
        Size = "4.5m";
    }
}

class SUVCar : Car
{
    public SUVCar()
    {
        Enigne = "2.0L";
        Seat = "7";
        Size = "5.5m";
    }
}

class ElectricCar : Car
{
    public ElectricCar()
    {
        Enigne = "Electric";
        Seat = "4";
        Size = "4.5m";
    }
}

class USSedanCar : SedanCar
{
    public USSedanCar()
    {
        Enigne = "2.0L";
        Seat = "4";
        Size = "4.5m";
    }
}

class USSUVCar : SUVCar
{
    public USSUVCar()
    {
        Enigne = "3.0L";
        Seat = "7";
        Size = "5.5m";
    }
}

class USElectricCar : ElectricCar
{
    public USElectricCar()
    {
        Enigne = "Electric";
        Seat = "4";
        Size = "4.5m";
    }
}

class ASIASedanCar : SedanCar
{
    public ASIASedanCar()
    {
        Enigne = "1.6L";
        Seat = "4";
        Size = "4.5m";
    }
}

class ASIASUVCar : SUVCar
{
    public ASIASUVCar()
    {
        Enigne = "2.0L";
        Seat = "7";
        Size = "5.5m";
    }
}

class ASIAElectricCar : ElectricCar
{
    public ASIAElectricCar()
    {
        Enigne = "Electric";
        Seat = "4";
        Size = "4.5m";
    }
}

interface Employee
{
    string Work();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Buy new car:");
        CarFactory usFactory = new USFactory();
        Car myCar = usFactory.CreateSedanCar();
        
        Console.WriteLine("\nMy car info:");
        Console.WriteLine(myCar.GetInfo());
        
    }
}