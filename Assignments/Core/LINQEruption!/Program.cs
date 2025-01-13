List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");

// ! Task 1 
Console.WriteLine("---------- Task 1 ----------");
Eruption? t1 = eruptions.FirstOrDefault(e => e.Location == "Chile");
Console.WriteLine(t1);
// ! Task 2
Console.WriteLine("---------- Task 2 ----------");
Eruption? t2 = eruptions.FirstOrDefault(e => e.Location == "Hawaiian Is");
if (t2 == null)
{
    Console.WriteLine("No Hawaiian Is Eruption found.");
}
else
{
    Console.WriteLine(t2);
}
// ! Task 3
Console.WriteLine("---------- Task 3 ----------");
Eruption? t3 = eruptions.FirstOrDefault(e => e.Location == "Greenland");
if (t3 == null)
{
    Console.WriteLine("No Greenland Eruption found.");
}
else
{
    Console.WriteLine(t3);
}
// ! Task 4
Console.WriteLine("---------- Task 4 ----------");
Eruption? t4 = eruptions.FirstOrDefault(e => e.Location == "New Zealand" && e.Year > 1900);
Console.WriteLine(t4);
// ! Task 5
Console.WriteLine("---------- Task 5 ----------");
List<Eruption> t5 = eruptions.Where(e => e.ElevationInMeters > 2000).ToList();
foreach(Eruption e in t5)
{
    Console.WriteLine(e);
}
// ! Task 6
Console.WriteLine("---------- Task 6 ----------");
List<Eruption> t6 = eruptions.Where(e => e.Volcano.StartsWith('L')).ToList();
foreach(Eruption e in t6)
{
    Console.WriteLine(e);
}
Console.WriteLine(t6.Count);
// ! Task 7
Console.WriteLine("---------- Task 7 ----------");
int t7 = eruptions.Max(e => e.ElevationInMeters);
Console.WriteLine(t7);
// ! Task 8
Console.WriteLine("---------- Task 8 ----------");
Eruption? t8 = eruptions.FirstOrDefault(e => e.ElevationInMeters == t7);
Console.WriteLine(t8.Volcano);
// ! Task 9
Console.WriteLine("---------- Task 9 ----------");
List<Eruption> t9 = eruptions.OrderBy(e => e.Volcano).ToList();
foreach(Eruption e in t9)
{
    Console.WriteLine(e.Volcano);
}
// ! Task 10
Console.WriteLine("---------- Task 10 ----------");
int t10 = eruptions.Sum(e => e.ElevationInMeters);
Console.WriteLine(t10);
// ! Task 11
Console.WriteLine("---------- Task 11 ----------");
Boolean t11 = eruptions.Any(e => e.Year == 2000);
if (t11)
{
    Console.WriteLine("An eruption did happen on the Year 2000.");
}
else
{
    Console.WriteLine("An erruption didn't happen on the Year 2000.");
}
// ! Task 12 
Console.WriteLine("---------- Task 12 ----------");
List<Eruption> t12 = eruptions.Where(e => e.Type == "Stratovolcano").Take(3).ToList();
foreach(Eruption e in t12)
{
    Console.WriteLine(e);
}
// ! Task 13
Console.WriteLine("---------- Task 13 ----------");
List<Eruption> t13 = eruptions.Where(e => e.Year < 1000).OrderBy(e => e.Volcano).ToList();
foreach(Eruption e in t13)
    Console.WriteLine(e);
// ! Task 14
Console.WriteLine("---------- Task 14 ----------");
List<string> t14 = eruptions.Where(e => e.Year < 1000).Select(e => e.Volcano).OrderBy(v => v).ToList();
foreach(string v in t14)
    Console.WriteLine(v);

static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}