using AnimeMaze.Models;
using System.Collections.Generic;

namespace AnimeMaze.Data;

public static class PlayerData
{
    public static int NumberOfPlayers = 1;
    public static List<Player> Players = new List<Player>();

    public static List<(int row, int col)> InitialPositions = new List<(int row, int col)> ();

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
        if (InitialPositions.Count == 0)
        {
            throw new InvalidOperationException("Debe generarse el laberinto primero");
        }
    
        NumberOfPlayers = numberOfPlayers;
        Players.Clear();
    
        // Asegurar que no se excedan las posiciones disponibles
        int maxPlayers = Math.Min(numberOfPlayers, InitialPositions.Count);
        
        for (int i = 0; i < maxPlayers; i++)
        {
            var position = InitialPositions[i];
            Players.Add(new Player(position));
        }
    }
}
