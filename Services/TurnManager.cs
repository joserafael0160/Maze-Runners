using AnimeMaze.Models;
using AnimeMaze.Data;

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
    public static int MovesLeft;

    static TurnManager()
    {
        ResetTurns();
    }

    public static void NextTurn()
{
    if (CurrentPlayer != null)
    {
        // Aplicar efectos temporales solo al final del turno completo
        CurrentPlayer.ApplyEffects();
        
        if (MovesLeft <= 1)
        {
            CurrentPlayer.HeroSelected?.Power.ReduceCooldown();
            CurrentPlayerIndex = (CurrentPlayerIndex + 1) % PlayerData.NumberOfPlayers;
            MovesLeft = CurrentPlayer.HeroSelected?.Speed ?? 0;
        }
        else
        {
            MovesLeft--;
        }
    }
    else
    {
        // Si el jugador no puede moverse, saltamos al siguiente jugador
        CurrentPlayerIndex = (CurrentPlayerIndex + 1) % PlayerData.NumberOfPlayers;
        MovesLeft = CurrentPlayer?.HeroSelected?.Speed ?? 0;
    }
}



    public static void ResetTurns()
    {
        CurrentPlayerIndex = 0;
        foreach (var player in PlayerData.Players)
        {
            player.TemporaryEffects.Clear();
            player.Position = player.InitialPosition;
            player.Health = player.HeroSelected?.Health ?? 0;
            player.Speed = player.HeroSelected?.Speed ?? 1; // Restablecer la velocidad
            player.Attack = player.HeroSelected?.Attack ?? 0;
        }

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
