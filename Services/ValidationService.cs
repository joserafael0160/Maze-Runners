using AnimeMaze.Models;
using AnimeMaze.Data;

namespace AnimeMaze.Services
{
  public static class ValidationService
  {
    private static Labyrinth game = LabyrinthData.Game;

    public static bool IsValidMove(int playerRow, int playerCol)
    {
      return (playerRow >= 0) && (playerCol >= 0) &&
             (playerRow < game.Maze.GetLength(0)) &&
             (playerCol < game.Maze.GetLength(1)) &&
             ((game.Maze[playerRow, playerCol].Type == Labyrinth.CellType.Road) ||
             (game.Maze[playerRow, playerCol]?.Type == Labyrinth.CellType.Exit) ||
             (game.Maze[playerRow, playerCol]?.Type == Labyrinth.CellType.Obstacle && game.Maze[playerRow, playerCol]?.Obstacle?.Health == 0) ||
             (game.Maze[playerRow, playerCol]?.Type == Labyrinth.CellType.Trap));
    }

    public static bool IsWinningMove(int playerRow, int playerCol)
    {
      return game.Maze[playerRow, playerCol]?.Type == Labyrinth.CellType.Exit;
    }

    public static bool CanAttack(int playerRow, int playerCol)
    {
      var cell = game.Maze[playerRow, playerCol];
      return (playerRow >= 0) && (playerCol >= 0) &&
             (playerRow < game.Maze.GetLength(0)) &&
             (playerCol < game.Maze.GetLength(1)) &&
             (cell?.Type == Labyrinth.CellType.Obstacle ||
              PlayerData.Players.Any(p => p.Position == (playerRow, playerCol)));
    }

    public static Labyrinth.Cell GetCell(int playerRow, int playerCol)
    {
      return game.Maze[playerRow, playerCol];
    }

    public static Player? GetPlayerAtPosition(int row, int col)
    {
      // Primero verificar límites del laberinto
      if (row < 0 || col < 0 ||
          row >= game.Maze.GetLength(0) ||
          col >= game.Maze.GetLength(1)) return null;

      return PlayerData.Players.FirstOrDefault(p =>
          p.Position.RowPosition == row &&
          p.Position.ColPosition == col
      );
    }
    public static void ResetValidationGame(Labyrinth newGame)
    {
      game = newGame;
    }
  }
}
