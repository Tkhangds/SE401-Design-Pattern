using System;

abstract class Kitchen
{
    public abstract Food CreateFood();
    
    public void ServeProcess()
    {
        Food food = CreateFood();
        Console.WriteLine(food.Prepare());
        Console.WriteLine(food.Cook());
        Console.WriteLine(food.Serve());
    }
}

class KitchenComTam : Kitchen
{
    public override Food CreateFood()
    {
        return new ComTam();
    }
}

class KitchenBanhMi : Kitchen
{
    public override Food CreateFood()
    {
        return new BanhMi();
    }
}

class KitchenXoi : Kitchen
{
    public override Food CreateFood()
    {
        return new Xoi();
    }
}

interface Food
{
    string Prepare();
    string Cook();
    string Serve();
}

class ComTam : Food
{
    public string Prepare()
    {
        return "Uop thit, mua gao";
    }

    public string Cook()
    {
        return "Nuong thit, nau com";
    }

    public string Serve()
    {
        return "Bo com,thit vao hop";
    }
}
class BanhMi : Food
{
    public string Prepare()
    {
        return "Mua banh mi, mua trung";
    }

    public string Cook()
    {
        return "Cat banh mi, chien trung";
    }

    public string Serve()
    {
        return "Bo trung vao banh mi";
    }
}

class Xoi : Food
{
    public string Prepare()
    {
        return "Ngam dau xanh";
    }

    public string Cook()
    {
        return "Nau xoi";
    }

    public string Serve()
    {
        return "Bo xoi vao hop";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Quy trinh phuc vu mon com:");
        Kitchen kitchenComTam = new KitchenComTam();
        kitchenComTam.ServeProcess();
        
        Console.WriteLine("\nQuy trinh phuc vu mon banh mi:");
        Kitchen kitchenBanhMi = new KitchenBanhMi();
        kitchenBanhMi.ServeProcess();
    }
}