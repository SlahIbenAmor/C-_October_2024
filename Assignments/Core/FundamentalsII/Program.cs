//! Three Basic Arrays
//* Create an integer array with the values 0 through 9 inside.
int[] NumArray = new int[] {0,1,2,3,4,5,6,7,8,9};

//* Create a string array with the names "Tim", "Martin", "Nikki", and "Sara".
string[] NamesArray = new string[] {"Tim", "Martin", "Nikki", "Sara"};

//* Create a boolean array of length 10. Then fill it with alternating true/false values, starting with true. (Tip: do this using logic! Do not hard-code the values in!)
bool[] BoolArray = new bool[10];
for (int i = 0; i < BoolArray.Length; i+=2){
    BoolArray[i] = true;
}

//! List of Flavors
//* Create a string List of ice cream flavors that holds at least 5 different flavors. (Feel free to add more than 5!)
List<string> IceCreamFlavors = new List<string>();
IceCreamFlavors.Add("Flavor1");
IceCreamFlavors.Add("Flavor2");
IceCreamFlavors.Add("Flavor3");
IceCreamFlavors.Add("Flavor4");
IceCreamFlavors.Add("Flavor5");

//* Output the length of the List after you added the flavors.
Console.WriteLine(IceCreamFlavors.Count);

//* Output the third flavor in the List.
Console.WriteLine(IceCreamFlavors[2]);

//* Now remove the third flavor using its index location.
IceCreamFlavors.RemoveAt(2);

//* Output the length of the List again. It should now be one fewer.
Console.WriteLine(IceCreamFlavors.Count);

//! User Dictionary
//* Create a dictionary that will store string keys and string values.
Dictionary<string,string> NewDictionary = new Dictionary<string, string>();

//* Add key/value pairs to the dictionary where:Each key is a name from your names array (this can be done by hand or using logic) Each value is a randomly selected flavor from your flavors List (remember Random from earlier?)
Random rand = new Random();
for(int i = 0; i < Names.Length; i++)
{
    NewDictionary.Add(NamesArray[i] , IceCreamFlavors[rand.Next(4)]);
}

//* Loop through the dictionary and print out each user's name and their associated ice cream flavor.
foreach(KeyValuePair<string,string> entry in NewDictionary)
{
    Console.WriteLine($"{entry.Key} - {entry.Value}");
}
