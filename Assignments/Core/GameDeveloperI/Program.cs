
      
        Enemy Goblin = new("Goblin");

       
        Attack Throw = new("Throw", 10);
        Attack Punch = new("Punch", 15);
        Attack Fireball = new("Fireball", 20);

        
        Goblin.AddAttack(Throw);
        Goblin.AddAttack(Punch);
        Goblin.AddAttack(Fireball);

        
        Goblin.RandomAttack();
        Goblin.RandomAttack();
    
