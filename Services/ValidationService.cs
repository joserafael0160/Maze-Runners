using AnimeMaze.Models;
using AnimeMaze.Data;

namespace AnimeMaze.Services;

public static class ValidationService
{
    private static Labyrinth game = LabyrinthData.Game;

    public static bool IsValidMove(int playerRow, int playerCol)
    {
        return (playerRow >= 0) && (playerCol >= 0) &&
               (playerRow < game.Maze.GetLength(0)) &&
               (playerCol < game.Maze.GetLength(1)) &&
               ((game.Maze[playerRow, playerCol].Type == Labyrinth.CellType.Road) ||
               (game.Maze[playerRow, playerCol].Type == Labyrinth.CellType.Exit) ||
               (game.Maze[playerRow, playerCol].Type == Labyrinth.CellType.Trap));
    }

    public static bool IsWinningMove(int playerRow, int playerCol)
    {
        return game.Maze[playerRow, playerCol].Type == Labyrinth.CellType.Exit;
    }
}
