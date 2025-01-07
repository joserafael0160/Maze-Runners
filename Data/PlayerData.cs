using AnimeMaze.Models;
using System.Collections.Generic;

namespace AnimeMaze.Data;

public static class PlayerData
{
    public static int NumberOfPlayers = 1;
    public static List<Player> Players = new List<Player>();

    public static List<(int row, int col)> InitialPositions = new List<(int row, int col)>
    {
        (1, 1),
        (4, 1),
        (7, 1),
        (6, 1),
    };

    public static void ResetPlayerPositions()
    {
        for (int i = 0; i < Players.Count; i++)
        {
            Players[i].Position = InitialPositions[i];
            Players[i].ResetHasWon();
        }
    }

    public static void InitializePlayers(int numberOfPlayers)
    {
        NumberOfPlayers = numberOfPlayers;
        Players.Clear();
        for (int i = 0; i < numberOfPlayers; i++)
        {
            var position = InitialPositions[i];
            Players.Add(new Player(position));
        }
    }
}
