namespace AnimeMaze;

public class MovementService
{
    private readonly ValidationService _validationService;
    private readonly GameStateService _gameStateService;

    public MovementService(ValidationService validationService, GameStateService gameStateService)
    {
        _validationService = validationService;
        _gameStateService = gameStateService;
    }

    public void MovePlayer(string direction)
    {
        int newPositionPlayerRow = _gameStateService.Game.PlayerRow;
        int newPositionPlayerCol = _gameStateService.Game.PlayerCol;

        switch (direction)
        {
            case "up":
                newPositionPlayerRow--;
                break;
            case "down":
                newPositionPlayerRow++;
                break;
            case "left":
                newPositionPlayerCol--;
                break;
            case "right":
                newPositionPlayerCol++;
                break;
        }

        if (_validationService.IsValidMove(newPositionPlayerRow, newPositionPlayerCol))
        {
            _gameStateService.Game.PlayerRow = newPositionPlayerRow;
            _gameStateService.Game.PlayerCol = newPositionPlayerCol;
        }
    }
}
