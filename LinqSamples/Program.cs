using FancyPower3k.DomainModel.Entities;
using FancyPower3k.DomainModel.Enums;
using LinqSamples.Extensions;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        var number = 1602;
        var digitSum = MathExtensions.DigitSum(number);

        // als Extension-Method
        digitSum = number.DigitSum();

        Console.WriteLine($"Quersumme von {number} ist {digitSum}.\n");

        var locations = new List<Location>
        {
            new Location
            {
                Address = "Hauptstr. 1, 12345 Berlin",
                Name = "Berlin",
            },
        };
        LinqSamples(Seed.CreateEmployees(locations));


        Console.WriteLine("Press any key to exit");
        // Ergebnis ist egal, deshalb discard result mit _
        _ = Console.ReadKey();
    }

    private static void LinqSamples(IEnumerable<Employee> employees)
    {
        Console.WriteLine("Top 10 Employees:");
        IEnumerable<Employee> top10 = employees.Take(10);
        var top10Salaries = top10.Select(e =>
        {
            // return anonymes Objekt
            Console.WriteLine($"{e.FirstName} {e.LastName}: {e.Salary}");
            return new
            {
                Name = e.FirstName + " " + e.LastName,
                e.Salary
            };
        });

        Console.WriteLine("IEnumerable ist lazy und wird erst bei ToList(), ToArray(), ToDictionary() etc. ausgefuehrt");

        var evaluatedTop10Salaries = top10Salaries.ToList();


        var avarageSalary = employees.Average(e => e.Salary);
        Console.WriteLine($"Avarage Salary: {avarageSalary}");
        var maxSalary = employees.Max(e => e.Salary);
        Console.WriteLine($"Max Salary: {maxSalary}");
        var minSalary = employees.Min(e => e.Salary);
        Console.WriteLine($"Min Salary: {minSalary}");

        // Exception wenn Liste leer ist
        Console.WriteLine("Erster Mitarbeiter: " + employees.First());

        // Default-Wert wenn Liste leer ist (bei Objekten ist default null)
        Console.WriteLine("Erster Mitarbeiter: " + employees.FirstOrDefault());

        // Wenn bei Single mehr als ein Element vorkommt fliegt eine Exception
        Console.WriteLine("Ein Mitarbeiter mit ID: " + employees.Take(1).Single());

        Console.WriteLine("\n\nAlle CEOs der Firma");
        employees
            .Where(e => e.Position == JobPosition.CEO)
            .ToList()
            .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName}"));

        Console.WriteLine("\n\nMitarbeiter sortieren nach Position und Gehalt");
        employees
            .OrderBy(e => e.Position)
            .ThenByDescending(e => e.Salary)
            .ToList()
            .ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} {e.Position} {e.Salary}"));


        Console.WriteLine("\n\nMitarbeiter nach FirstName gruppieren");
        IEnumerable<IGrouping<string, Employee>> groups = employees.GroupBy(e => e.FirstName);
        groups.Select(g => new
        {
            Name = g.Key,
            Count = g.Count(),
            AverageSalary = g.Average(e => e.Salary),
            MaxSalary = g.Max(e => e.Salary),
            MinSalary = g.Min(e => e.Salary),
        }).OrderByDescending(g => g.Count)
            .ToList()
            .ForEach(g => Console.WriteLine($"{g.Name} kommt {g.Count}x vor und durchschnittlicher Gehalt ist {g.AverageSalary}, Max: {g.MaxSalary}, Min: {g.MinSalary}"));


        Console.WriteLine("\n\nProjektion einer verschachtelten Aufzaehlung abflachen");
        IEnumerable<Employee> bigList = new List<Employee[]>
        {
            employees.Take(5).ToArray(),
            employees.Skip(20).Take(5).ToArray(),
            employees.Skip(40).Take(5).ToArray(),
        }.SelectMany(e => e); // flacht die verschachtelte Aufzaehlung ab

        bigList.ToList().ForEach(Console.WriteLine);

        var startValue = new StringBuilder();
        var sb = employees.Take(10).Aggregate(startValue, AppendLine);

        static StringBuilder AppendLine(StringBuilder sb, Employee e)
        {
            return sb.AppendLine(e.FirstName + " " + e.LastName);
        }
        Console.WriteLine(sb.ToString());


        Console.WriteLine("\n\nMitarbeiter gruppieren nach Position\n");
        var dict = employees
            .Select(e => new { e.Position, Employee = e })
            .GroupBy(e => e.Position)
            .ToDictionary(g => g.Key, g => g.Select(e => e.Employee).Aggregate(new StringBuilder(), AppendLine));

        foreach (var entry in dict)
        {
            Console.WriteLine($"Position: {entry.Key}");
            Console.WriteLine($"\t{entry.Value}");
        }
    }
}