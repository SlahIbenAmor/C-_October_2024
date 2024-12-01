public class Enemy
{
    public string Name { get; }
    private int health; 
    public List<Attack> AttackList { get; }

    public Enemy(string name)
    {
        this.Name = name;
        this.health = 100;
        this.AttackList = new List<Attack>(); 
    }

    public void RandomAttack()
    {
        if (AttackList.Count == 0)
        {
            Console.WriteLine($"{Name} has no attacks!");
            return;
        }

        Random rand = new();
        int attackIndex = rand.Next(this.AttackList.Count);
        Attack selectedAttack = AttackList[attackIndex];
        Console.WriteLine($"{Name} performs {selectedAttack.Name} dealing {selectedAttack.DamageAmount} damage.");
    }

    public void AddAttack(Attack attack)
    {
        AttackList.Add(attack);
        Console.WriteLine($"Attack {attack.Name} added to {Name}.");
    }
}