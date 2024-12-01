class Soda : Drink
{
    public bool IsDiet;
    public Soda(string n, string col, double t, int cal, bool id) : base(n, col, t, true, cal)
    {
        IsDiet = id;
    }

    public override void ShowDrink()
    {
        base.ShowDrink();
        Console.WriteLine($"Is Diet: {IsDiet}");
    }
}