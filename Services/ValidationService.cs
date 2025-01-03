using AnimeMaze.Models;
namespace AnimeMaze;

public class ValidationService
{
    private readonly GameStateService _gameStateService;

    public ValidationService(GameStateService gameStateService)
    {
        _gameStateService = gameStateService;
    }

    public bool IsValidMove(int playerRow, int playerCol)
    {
        var game = _gameStateService.Game;
        return (playerRow >= 0) && (playerCol >= 0) &&
               (playerRow < game.Maze.GetLength(0)) &&
               (playerCol < game.Maze.GetLength(1)) &&
               (game.Maze[playerRow, playerCol] == Labyrinth.Cell.Road);
    }
}
