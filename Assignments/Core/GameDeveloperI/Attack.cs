public class Attack
{
    public string Name { get; }
    public int DamageAmount { get; } 

    public Attack(string name, int damageAmount)
    {
        this.Name = name;
        this.DamageAmount = damageAmount;
    }
}