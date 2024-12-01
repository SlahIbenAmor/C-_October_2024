class Vehicle 
{
    string Name;
    int Number;
    string Color;
    bool HasEngine;
    int Mileage = 0;

    public Vehicle(string name, int number, string color, bool hasEngine )
    {
        Name = name;
        Number = number;
        Color = color;
        HasEngine = hasEngine;
    }

    public Vehicle (string name,string color)
    {
        Name = name;
        Color = color;
        Number= 0;
        HasEngine = true;
    }

    public void ShowInfo()
    {
        Console.WriteLine(Name);
        Console.WriteLine(Number);
        Console.WriteLine(Color);
        Console.WriteLine(HasEngine);
        Console.WriteLine(Mileage);
    }

    public void Travel(int distance) 
    {
        Mileage+=distance;
        Console.WriteLine($"The Vehicle has travelled {Mileage} miles");
    }
}