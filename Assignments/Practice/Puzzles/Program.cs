// ! Coin Flip
static string FlipCoin()
{
    Random random = new();
    return random.Next(2) == 0 ? "Pile" : "Face";
}

Console.WriteLine(FlipCoin());


// ! Dice Roll
static int ThrowDice(int faces)
{
    Random random = new();
    return random.Next(faces) + 1;
}

Console.WriteLine(ThrowDice(6));


// ! Stat Roll
static List<int> DiceStats(int throwsCount)
{
    int maxRoll = 0;
    List<int> results = new();
    for (int i = 0; i < throwsCount; i++)
    {
        int currentThrow = ThrowDice(6);
        results.Add(currentThrow);
        if (currentThrow > maxRoll)
            maxRoll = currentThrow;
    }

    Console.WriteLine($"The highest throw was: {maxRoll}");
    return results;
}

List<int> results = DiceStats(4);
Console.WriteLine("Throws: ");
foreach (int throwResult in results)
Console.WriteLine(throwResult);

// ! Roll Until...
static void KeepRolling(int target)
{
    int attempts = 1;
    int result = ThrowDice(6);
    while (result != target)
    {
        attempts++;
        result = ThrowDice(6);
    }
    Console.WriteLine($"Rolled a {target} after {attempts} attempts.");
}

Console.WriteLine("Example 1:");
KeepRolling(4);
Console.WriteLine("Example 2:");
KeepRolling(5);

// ! Optional Bonus
static void StartGame()
{
    string firstPlayer, secondPlayer;
    int diceFaces, diceCount;

    // Get player names
    Console.WriteLine("Player 1, enter your name: ");
    firstPlayer = Console.ReadLine();
    Console.Clear();
    Console.WriteLine("Player 2, enter your name: ");
    secondPlayer = Console.ReadLine();
    Console.Clear();

    // Get dice size
    Console.WriteLine("Enter the number of faces on the dice: ");
    diceFaces = Int32.Parse(Console.ReadLine());
    Console.Clear();

    // Get dice count
    Console.WriteLine("Enter the number of dice: ");
    diceCount = Int32.Parse(Console.ReadLine());
    Console.Clear();

    // Display game details
    Console.WriteLine("----------------- Game Details -----------------");
    Console.WriteLine($"Player 1: {firstPlayer}");
    Console.WriteLine($"Player 2: {secondPlayer}");
    Console.WriteLine($"Dice Faces: {diceFaces}");
    Console.WriteLine($"Dice Count: {diceCount}");

    int scorePlayer1 = 0, scorePlayer2 = 0;

    // Play the game
    Console.WriteLine($"{firstPlayer}'s turn: ");
    scorePlayer1 = PlayTurn(diceFaces, diceCount);
    Console.WriteLine($"Score: {scorePlayer1}");

    Console.WriteLine($"{secondPlayer}'s turn: ");
    scorePlayer2 = PlayTurn(diceFaces, diceCount);
    Console.WriteLine($"Score: {scorePlayer2}");

    // Display results
    if (scorePlayer1 > scorePlayer2)
    {
        Console.WriteLine($"Congratulations {firstPlayer}, you won with a score of {scorePlayer1}!");
    }
    else if (scorePlayer2 > scorePlayer1)
    {
        Console.WriteLine($"Congratulations {secondPlayer}, you won with a score of {scorePlayer2}!");
    }
    else
    {
        Console.WriteLine("It's a tie!");
    }
}

static int PlayTurn(int diceFaces, int diceCount)
{
    int totalScore = 0;
    Console.WriteLine("Rolls:");
    for (int i = 0; i < diceCount; i++)
    {
        int roll = ThrowDice(diceFaces);
        Console.Write($" {roll}");
        totalScore += roll;
    }
    Console.WriteLine(); 
    return totalScore;
}

StartGame();
