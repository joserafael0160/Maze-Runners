using AnimeMaze.Services;
using AnimeMaze.Data;

namespace AnimeMaze.Models;

public enum Direction { Up, Down, Left, Right }

public class Player
{
    public (int RowPosition, int ColPosition) Position { get; set; }
    public (int RowPosition, int ColPosition) InitialPosition { get; }
    public Hero? HeroSelected { get; set; }
    public bool HasWon { get; private set; } = false;
    public int Health { get; set; }
    public int Speed { get; set; }
    public int Attack { get; set; }
    public Direction FacingDirection { get; set; }
    public List<TemporaryEffect> TemporaryEffects { get; } = [];

    public Player((int row, int col) position)
    {
        Position = position;
        InitialPosition = position;
        FacingDirection = Direction.Down;
    }

    public void InitializeStats()
    {
        if (HeroSelected != null)
        {
            Health = HeroSelected.Health;
            Speed = HeroSelected.Speed;
            Attack = HeroSelected.Attack;
        }
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

    public void AttackTarget()
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

        if (ValidationService.CanAttack(attackPosition.row, attackPosition.col))
        {
            var cell = ValidationService.GetCell(attackPosition.row, attackPosition.col);
            var player = ValidationService.GetPlayerAtPosition(attackPosition.row, attackPosition.col);

            if (cell.Obstacle != null && cell.Obstacle.Health != 0)
            {
                cell.Obstacle.TakeDamage(this.Attack);
                if (cell.Obstacle.IsBroken())
                {
                    cell.Obstacle = null;
                    cell.Type = Labyrinth.CellType.Road;
                }
            }
            else if (player != null)
            {
                player.Health -= this.Attack;
                if (player.Health <= 0)
                {
                    player.Position = player.InitialPosition;
                    player.InitializeStats();
                }
            }
        }
        TurnManager.NextTurn();
    }


    public void ApplyEffects()
    {
        foreach (var effect in TemporaryEffects.ToList())
        {
            effect.DecrementTurn();
            if (effect.TurnsRemaining <= 0)
            {
                effect.Remove(this);
                TemporaryEffects.Remove(effect);
            }
        }
    }

    public void AddTemporaryEffect(TemporaryEffect effect)
    {

        TemporaryEffects.Add(effect);
        effect.Apply(this);
        if (Health <= 0)
        {
            Position = InitialPosition;
            InitializeStats();
        }
    }

    public void ResetHasWon()
    {
        HasWon = false;
    }
}
