MeleeFighter melee = new MeleeFighter("Melee Fighter");
RangedFighter ranged = new RangedFighter("Ranged Fighter");
MagicCaster magicCaster = new MagicCaster("Magic Caster");

melee.PerformAttack(ranged, melee.AttackList[1]); 

melee.Rage();


ranged.PerformAttack(melee, ranged.AttackList[0]); 


ranged.Dash();


ranged.PerformAttack(melee, ranged.AttackList[0]);


magicCaster.PerformAttack(melee, magicCaster.AttackList[0]); 


magicCaster.Heal(ranged);


magicCaster.Heal(magicCaster);
