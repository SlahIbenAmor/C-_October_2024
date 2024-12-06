public class Enemy
{
    public string Name { get; }
    protected int health;
    public List<Attack> AttackList { get; }

    public int Health { get { return health; } } 

    public Enemy(string name, int initialHealth = 100)
    {
        this.Name = name;
        this.health = initialHealth;
        this.AttackList = new List<Attack>();
    }

    public void PerformAttack(Enemy target, Attack chosenAttack)
    {
        target.health -= chosenAttack.DamageAmount; 
        Console.WriteLine($"{Name} attacks {target.Name}, dealing {chosenAttack.DamageAmount} damage and reducing {target.Name}'s health to {target.health}!");
    }

    public void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
        Console.WriteLine($"Attack {attack.Name} added to {Name}.");
    }
}
