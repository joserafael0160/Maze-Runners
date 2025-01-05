using AnimeMaze.Models;
using AnimeMaze.Data;

namespace AnimeMaze;

public static class ValidationService
{
    private static Labyrinth game = LabyrinthData.Game;

    public static bool IsValidMove(int playerRow, int playerCol)
    {
        return (playerRow >= 0) && (playerCol >= 0) &&
               (playerRow < game.Maze.GetLength(0)) &&
               (playerCol < game.Maze.GetLength(1)) &&
               (game.Maze[playerRow, playerCol] == Labyrinth.Cell.Road);
    }
}
