public class Log
{
    public string MagazineName { get; set; }
    public string Genre { get; set; }
    public int NumberOfPages { get; set; }
    public DateTime PublicationDate { get; set; }

    public override bool Equals(object obj)
    {
        return obj is Log log &&
               string.Equals(Genre, log.Genre, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Genre.ToLower().GetHashCode();
    }
}

class Program
{
    static void Main()
    {
        Log[] logs = {
            new Log { MagazineName = "National Geographic", Genre = "Nature", NumberOfPages = 100, PublicationDate = new DateTime(2022, 1, 1) },
            new Log { MagazineName = "Vogue", Genre = "Fashion", NumberOfPages = 120, PublicationDate = new DateTime(2021, 5, 1) },
            new Log { MagazineName = "Time", Genre = "Politics", NumberOfPages = 60, PublicationDate = new DateTime(2022, 3, 1) },
            new Log { MagazineName = "Sports Illustrated", Genre = "Sport", NumberOfPages = 80, PublicationDate = new DateTime(2023, 4, 1) },
            new Log { MagazineName = "AutoTrader", Genre = "Auto", NumberOfPages = 90, PublicationDate = new DateTime(2021, 8, 1) }
        };

        bool allMoreThanThirtyPages = logs.All(log => log.NumberOfPages > 30);
        Console.WriteLine($"All magazines have more than 30 pages: {allMoreThanThirtyPages}");

        bool allSpecificGenres = logs.All(log => log.Genre == "Politics" || log.Genre == "Fashion" || log.Genre == "Sport");
        Console.WriteLine($"All magazines are in the genre 'Politics', 'Fashion', or 'Sport': {allSpecificGenres}");

        bool anyGardenAndGarden = logs.Any(log => log.Genre == "Garden and Garden");
        Console.WriteLine($"At least one magazine in the 'Garden and Garden' genre: {anyGardenAndGarden}");

        bool anyFishing = logs.Any(log => log.Genre == "Fishing");
        Console.WriteLine($"At least one magazine in the 'Fishing' genre: {anyFishing}");

        bool containsHunting = logs.Any(log => log.Genre.Equals("Hunting", StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Array contains 'Hunting' logs: {containsHunting}");

        Log firstPublishedIn2022 = logs.FirstOrDefault(log => log.PublicationDate.Year == 2022);
        Console.WriteLine($"First magazine published in 2022: {firstPublishedIn2022?.MagazineName}");

        Log lastAutoMagazine = logs.LastOrDefault(log => log.MagazineName.StartsWith("Auto"));
        Console.WriteLine($"Latest journal whose title begins with 'Auto': {lastAutoMagazine?.MagazineName}");
    }
}
