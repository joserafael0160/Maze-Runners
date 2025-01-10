using AnimeMaze.Services;
using AnimeMaze.Data;

namespace AnimeMaze.Models;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class Player
{
    public (int RowPosition, int ColPosition) Position { get; set; }
    public (int RowPosition, int ColPosition) InitialPosition { get; }
    public Hero? HeroSelected { get; set; }
    public bool HasWon { get; private set; } = false;
    public int Health { get; set; }
    public Direction FacingDirection { get; set; }

    public Player((int row, int col) position)
    {
        Position = position;
        InitialPosition = position;
        FacingDirection = Direction.Right;
    }

    public bool MovePlayer(string direction)
    {
        int newPositionRow = Position.RowPosition;
        int newPositionCol = Position.ColPosition;

        switch (direction.ToLower())
        {
            case "up":
                newPositionRow--;
                FacingDirection = Direction.Up;
                break;
            case "down":
                newPositionRow++;
                FacingDirection = Direction.Down;
                break;
            case "left":
                newPositionCol--;
                FacingDirection = Direction.Left;
                break;
            case "right":
                newPositionCol++;
                FacingDirection = Direction.Right;
                break;
        }

        if (ValidationService.IsValidMove(newPositionRow, newPositionCol))
        {
            Position = (newPositionRow, newPositionCol);
            if (ValidationService.IsWinningMove(newPositionRow, newPositionCol))
            {
                HasWon = true;
                return true;
            }
            TurnManager.NextTurn();
        }
        return false;
    }

    public void Attack()
    {
        (int row, int col) attackPosition = Position;

        switch (FacingDirection)
        {
            case Direction.Up:
                attackPosition.row--;
                break;
            case Direction.Down:
                attackPosition.row++;
                break;
            case Direction.Left:
                attackPosition.col--;
                break;
            case Direction.Right:
                attackPosition.col++;
                break;
        }

        var targetPlayer = PlayerData.Players.FirstOrDefault(p => p.Position == attackPosition);
        if (targetPlayer != null)
        {
            targetPlayer.Health -= this.HeroSelected?.Attack ?? 0;
            if (targetPlayer.Health <= 0)
            {
                targetPlayer.Position = targetPlayer.InitialPosition;
                targetPlayer.Health = targetPlayer.HeroSelected?.Health ?? 0;
            }
        }
        TurnManager.NextTurn();

    }

    public void ResetHasWon()
    {
        HasWon = false;
    }
}
