using AnimeMaze.Models;
using AnimeMaze.Data;
using System.Collections.Generic;

namespace AnimeMaze.Services;

public static class TurnManager
{
    public static int CurrentPlayerIndex = 0;
    public static Player? CurrentPlayer
    {
        get
        {
            if (PlayerData.Players.Count > 0)
            {
                return PlayerData.Players[CurrentPlayerIndex];
            }
            return null;
        }
    }

    public static void NextTurn()
    {
        CurrentPlayerIndex++;
        if (CurrentPlayerIndex >= PlayerData.NumberOfPlayers)
        {
            CurrentPlayerIndex = 0;
        }
    }

    public static void ResetTurns()
    {
        CurrentPlayerIndex = 0;
    }
}
