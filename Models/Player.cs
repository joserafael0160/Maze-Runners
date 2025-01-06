using AnimeMaze.Services;

namespace AnimeMaze.Models;

public class Player
{
    public (int RowPosition, int ColPosition) Position { get; set; }
    public Hero? HeroSelected { get; set; }
    public bool HasWon { get; private set; } = false; // Nueva propiedad para indicar si el jugador ha ganado

    public Player((int row, int col) position)
    {
        Position = position;
    }

    public void MovePlayer(string direction)
    {
        int newPositionRow = Position.RowPosition;
        int newPositionCol = Position.ColPosition;

        switch (direction.ToLower())
        {
            case "up":
                newPositionRow--;
                break;
            case "down":
                newPositionRow++;
                break;
            case "left":
                newPositionCol--;
                break;
            case "right":
                newPositionCol++;
                break;
        }

        if (ValidationService.IsValidMove(newPositionRow, newPositionCol))
        {
            Position = (newPositionRow, newPositionCol);
            if (ValidationService.IsWinningMove(newPositionRow, newPositionCol))
            {
                HasWon = true;
            }
            TurnManager.NextTurn();
        }
    }
}
