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