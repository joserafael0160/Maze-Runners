namespace AnimeMaze.Services;

using AnimeMaze.Models;
using AnimeMaze.Data;

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
    public static int MovesLeft;

    static TurnManager()
    {
        if (CurrentPlayer != null && CurrentPlayer.HeroSelected != null)
        {
            MovesLeft = CurrentPlayer.HeroSelected.Speed;
        }
        else
        {
            MovesLeft = 0;
        }
    }

    public static void NextTurn()
    {
        if (CurrentPlayer != null)
        {
            if (MovesLeft == 1)
            {
                CurrentPlayer.HeroSelected?.Power.ReduceCooldown();
                CurrentPlayerIndex++;
                if (CurrentPlayerIndex >= PlayerData.NumberOfPlayers)
                {
                    CurrentPlayerIndex = 0;
                }
                MovesLeft = CurrentPlayer.HeroSelected?.Speed ?? 0; 
            }
            else
            {
                MovesLeft--;
            }
        }
    }

    public static void ResetTurns()
    {
        CurrentPlayerIndex = 0;
        if (CurrentPlayer != null && CurrentPlayer.HeroSelected != null)
        {
            MovesLeft = CurrentPlayer.HeroSelected.Speed;
        }
        else
        {
            MovesLeft = 0; 
        }
    }
}
