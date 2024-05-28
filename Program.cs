var random = new Random ();

// Local Functions
int[] setGameData ()
{
  var gameData = new int[10];
  gameData[0] = 30;   // Monster HP
  gameData[1] = 25;   // Player HP
  gameData[2] = 25;   // Player Max HP
  gameData[3] = 3;    // Monster Min Attack
  gameData[4] = 8;    // Monster Max Attack
  gameData[5] = 3;    // Player Min Attack
  gameData[6] = 7;    // Player Max Attack
  gameData[7] = 8;    // Player Min Heal
  gameData[8] = 12;   // Player Max Heal
  gameData[9] = 0;    // Heal Cool Down

  return gameData;
}


void PlayerAttack (int[] gameData)
{
  int attack = random.Next(gameData[5], gameData[6] + 1);
  gameData[0] -= attack;
}

void PlayerHeal (int[] gameData)
{
  if (gameData[9] > 0) {
    Console.WriteLine("Unable to use heal at this time.");
    return;
  }

  int heal = random.Next(gameData[7], gameData[8] + 1);
  gameData[1] = gameData[1] + heal > gameData[2] ? gameData[2] : gameData[1] + heal;
  gameData[9] = 2;
}

void HealRegenerate (int[] gameData)
{
  if (gameData[9] > 0) {
    gameData[9]--;
  }
}

void MonsterAttack (int[] gameData)
{
  int attack = random.Next(gameData[3], gameData[4] + 1);
  gameData[1] -= attack;
}

// Game Loop
bool isActive = true;
int[] gameData = setGameData();

while (isActive)
{
  Console.WriteLine($"\nMonster: {gameData[0]} \t \t You: {gameData[1]}");
  
  bool isValid = false;

  while (!isValid)
  {
    Console.WriteLine($"\nChoose an action: Attack or Heal\n");
    string? action = Console.ReadLine();

    switch (action)
    {
      case "Attack":
        PlayerAttack(gameData);
        isValid = true;
        break;
      case "Heal":
        PlayerHeal(gameData);
        isValid = true;
        break;
      default:
        Console.WriteLine("Not a valid action. Try again");
        break;
    }
  }

  if (gameData[0] > 0)
  {
    HealRegenerate(gameData);
    MonsterAttack(gameData);

    if (gameData[1] <= 0)
    {
        Console.WriteLine("\n\nYou have been defeated. Game over.\n\n");
        isActive = false;
    }
  }
  else
  {
    Console.WriteLine("\n\nYou have defeated the Monster!\n\n");
    isActive = false;
  }

  if (!isActive)
  {
      Console.WriteLine("Would you like to play again? (Y/y)");
      string? response = Console.ReadLine();

      if (!string.IsNullOrEmpty(response) && response.ToLower() == "y")
      {
          isActive = true;
          gameData = setGameData();
          Console.Clear();
      }
  }
}