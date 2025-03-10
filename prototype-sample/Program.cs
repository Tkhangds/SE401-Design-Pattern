namespace prototype_sample;

abstract class Show
{
    public Show(string name, string time)
    {
        Name = name;
        Time = time;
    }
    public string Name { get; set; }
    public string Time { get; set; }
    public string Type { get; init; }

    public abstract Show Clone();
}

class Film : Show
{
    public Film(string name, string time) : base(name, time)
    {
        Type = "Film";
    }

    public override Show Clone()
    {
        return new Film(Name, Time);
    }
}

class Concert : Show
{
    public Concert(string name, string time): base(name, time)
    {
        Type = "Concert";
    }

    public override Show Clone()
    {
        return new Concert(Name, Time);
    }
}

class TVShow : Show
{
    public TVShow(string name, string time): base(name, time)
    {
        Type = "TV Show";
    }

    public override Show Clone()
    {
        return new TVShow(Name, Time);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list of shows
        Show[] shows = new Show[]
        {
            new Film("The Shawshank Redemption", "2h 22m"),
            new Concert("Live Aid", "13h 4m"),
            new TVShow("Friends", "22m")
        };

        Console.WriteLine("Original shows:");
        //Show the original shows
        foreach (Show show in shows)
        {
            Console.WriteLine($"{show.Type}: {show.Name} ({show.Time})");
        }
        
        // Make some change to the shows
        shows[0].Name = "The Godfather";
        shows[1].Time = "14h 30m";
        shows[2].Time = "15h 30m";
        
        // Clone the shows
        Show[] clonedShows = new Show[shows.Length];
        for (int i = 0; i < shows.Length; i++)
        {
            clonedShows[i] = shows[i].Clone();
        }

        Console.WriteLine('\n');
        Console.WriteLine("Cloned shows:");
        // Display the cloned shows
        foreach (Show show in clonedShows)
        {
            Console.WriteLine($"{show.Type}: {show.Name} ({show.Time})");
        }
    }
}