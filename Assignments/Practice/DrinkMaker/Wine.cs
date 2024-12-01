class Wine : Drink
{
    public string Region;
    public int Year;
    public Wine(string n, string col, double t, int cal, string r, int y) : base(n, col, t, false, cal)
    {
        Region = r;
        Year = y;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Region: {Region}");
        Console.WriteLine($"Year: {Year}");
    }
}