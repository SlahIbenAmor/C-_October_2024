public class MeleeFighter : Enemy
{
    public MeleeFighter(string name) : base(name, 120)  health
    {
        
        AddAttack(new Attack("Punch", 20));
        AddAttack(new Attack("Kick", 15));
        AddAttack(new Attack("Tackle", 25));
    }

    
    public void Rage()
    {
        Random rand = new();
        int attackIndex = rand.Next(AttackList.Count);
        Attack selectedAttack = AttackList[attackIndex];
        Console.WriteLine($"{Name} enters a rage! {selectedAttack.Name} deals an additional 10 damage.");
        selectedAttack = new Attack(selectedAttack.Name, selectedAttack.DamageAmount + 10);
              PerformAttack(this, selectedAttack);
    }
}
