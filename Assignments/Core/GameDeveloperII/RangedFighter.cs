
     public class RangedFighter : Enemy
{
    public int Distance { get; private set; }

    public RangedFighter(string name) : base(name, 100)
    {
               AddAttack(new Attack("Shoot an Arrow", 20));
        AddAttack(new Attack("Throw a Knife", 15));
        this.Distance = 5; 
    }

  
    public void Dash()
    {
        Distance = 20;
        Console.WriteLine($"{Name} dashes and increases distance to {Distance}.");
    }

        public new void PerformAttack(Enemy target, Attack chosenAttack)
    {
        if (Distance < 10 && (chosenAttack.Name == "Shoot an Arrow" || chosenAttack.Name == "Throw a Knife"))
        {
            Console.WriteLine($"{Name} is too close to attack! Distance is {Distance}.");
        }
        else
        {
            base.PerformAttack(target, chosenAttack);
        }
    }
}

