namespace builder_pattern;

public interface IDietBuilder
{
    void AddProteins();
    void AddCarbohydrates();
    void AddVegetables();
    void AddDrink();
}

public class MediterraneanDietBuilder : IDietBuilder
{
    private Diet _diet = new Diet();

    public MediterraneanDietBuilder()
    {
        this.Reset();
    }
    
    public void Reset()
    {
        this._diet = new Diet();
    }
    
    public void AddProteins()
    {
        _diet.Add("Fish");
    }

    public void AddCarbohydrates()
    {
        _diet.Add("Olive Oil");
    }

    public void AddVegetables()
    {
        _diet.Add("Fresh Vegetables");
    }

    public void AddDrink()
    {
        _diet.Add("Red Wine");
    }
    
    public Diet GetDiet()
    {
        Diet result = this._diet;

        this.Reset();

        return result;
    }
}

public class DashDietBuilder : IDietBuilder
{
    private Diet _diet = new Diet();

    public DashDietBuilder()
    {
        this.Reset();
    }
    
    public void Reset()
    {
        this._diet = new Diet();
    }
    
    public void AddProteins()
    {
        _diet.Add("Chicken");
    }

    public void AddCarbohydrates()
    {
        _diet.Add("Brown Rice");
    }

    public void AddVegetables()
    {
        _diet.Add("Green Vegetables");
    }

    public void AddDrink()
    {
        _diet.Add("Fruit Juice");
    }
    
    public Diet GetDiet()
    {
        Diet result = this._diet;

        this.Reset();

        return result;
    }
}

public class VegetarianDietBuilder : IDietBuilder
{
    private Diet _diet = new Diet();

    public VegetarianDietBuilder()
    {
        this.Reset();
    }
    
    public void Reset()
    {
        this._diet = new Diet();
    }
    
    public void AddProteins()
    {
        _diet.Add("Tofu");
    }

    public void AddCarbohydrates()
    {
        _diet.Add("Potatoes");
    }

    public void AddVegetables()
    {
        _diet.Add("Mixed Vegetables");
    }

    public void AddDrink()
    {
        _diet.Add("Water");
    }
    
    public Diet GetDiet()
    {
        Diet result = this._diet;

        this.Reset();

        return result;
    }
}
public class Diet
{
    private List<object> _parts = new List<object>();
        
    public void Add(string part)
    {
        this._parts.Add(part);
    }
        
    public string DietParts()
    {
        string str = string.Empty;

        for (int i = 0; i < this._parts.Count; i++)
        {
            str += this._parts[i] + ", ";
        }

        str = str.Remove(str.Length - 2); // removing last ",c"

        return "Diet menu: " + str + "\n";
    }
}

public class DietDirector
{
    private IDietBuilder _builder;
        
    public IDietBuilder Builder
    {
        set { _builder = value; } 
    }
    
    public void BuildDietWithoutDrink()
    {
        this._builder.AddProteins();
        this._builder.AddCarbohydrates();
        this._builder.AddVegetables();
    }
        
    public void BuildDiet()
    {
        this._builder.AddProteins();
        this._builder.AddCarbohydrates();
        this._builder.AddVegetables();
        this._builder.AddDrink();
    }
}

class Program
{
    static void Main(string[] args)
    {
        var director = new DietDirector();
        var builder = new VegetarianDietBuilder();
        director.Builder = builder;
            
        Console.WriteLine("Standard basic product:");
        director.BuildDietWithoutDrink();
        Console.WriteLine(builder.GetDiet().DietParts());

        Console.WriteLine("Standard full featured product:");
        director.BuildDiet();
        Console.WriteLine(builder.GetDiet().DietParts());
        
        Console.WriteLine("Custom product:");
        builder.AddCarbohydrates();
        builder.AddDrink();
        Console.Write(builder.GetDiet().DietParts());
    }
}