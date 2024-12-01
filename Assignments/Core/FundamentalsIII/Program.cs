// //! 1. Iterate and print values
using System.Diagnostics.Metrics;

static void PrintList(List<string> MyList)
{
    for(int i=0; i<MyList.Count; i++)
    {
        Console.WriteLine(MyList[i]);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

//! 2. Print Sum
static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach(int number in IntList)
    {
        sum+=number;
    }
    Console.WriteLine($"the total is sum {sum}");

}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
SumOfNumbers(TestIntList);

//! 3. Find Max
static int FindMax(List<int> IntList)
{
    int biggestNumber = IntList[0];
    foreach(int num in IntList)
    {
        if(num > biggestNumber){
            biggestNumber = num;
        }
    }
    return biggestNumber;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
FindMax(TestIntList2);

//! 4. Square the Values
static List<int> SquareValues(List<int> IntList)
{
    for(int i = 0; i < IntList.Count; i++){
        IntList[i] *= IntList[i];
    }
    return IntList;
}
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
SquareValues(TestIntList3);

//! 5. Replace Negative Numbers with 0
static int[] NonNegatives(int[] IntArray)
{
    for(int i=0; i<IntArray.Length; i++)
    {
        if(IntArray[i]<0)
        {
            IntArray[i]=0;
        }
    }
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
NonNegatives(TestIntArray);

//! 6. Print Dictionary
static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach(KeyValuePair<string,string> entry in MyDictionary)
    {
        Console.WriteLine($"{entry.Key} - {entry.Value}");
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

//! 7. Find Key
static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
foreach(KeyValuePair<string,string> entry in MyDictionary)
{
    if(SearchTerm==entry.Key)
    {
        return true;
    }
}
return false;
}
Console.WriteLine(FindKey(TestDict, "RealName"));
Console.WriteLine(FindKey(TestDict, "Name"));

//! 8. Generate a Dictionary
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    // Your code here
    Dictionary<string,int> MyDictionary2 = new Dictionary<string, int>();
    for(int i =0; i<Names.Count; i++)
    {
        MyDictionary2.Add(Names[i], Numbers[i]);
    }
    return MyDictionary2;
}
List<string> Names = new List<string>(){"Julie","Harold","James","Monica"};
List<int> Numbers = new List<int>() {6,12,7,10};
Console.WriteLine(GenerateDictionary(Names,Numbers));
