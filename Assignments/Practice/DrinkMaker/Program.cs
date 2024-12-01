﻿Soda Coke = new Soda("Coca Cola", "brown", 38, 140, false);
Coffee Cappuccino = new Coffee("French Vanilla", "light brown", 120, 110, "light", "coffee beans");
Wine Merlot = new Wine("Merlot", "red", 32, 120, "Bordeaux", 1992);

// Create a list of all of our drinks
List<Drink> AllBeverages = new List<Drink>();
AllBeverages.Add(Coke);
AllBeverages.Add(Cappuccino);
AllBeverages.Add(Merlot);

// Loop through the list and call the ShowDrink for each
foreach(Drink d in AllBeverages)
{
    d.ShowDrink();
}

// This is invalid because we cannot make instances across child classes
// Coffee MyDrink = new Soda("Coca Cola", "brown", 38, 140, false);