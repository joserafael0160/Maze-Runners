using AnimeMaze.Data;
using System.Linq;
using AnimeMaze.Logic;

namespace AnimeMaze.Models;

public class Labyrinth
{
    public Cell[,] Maze { get; }

    public class Cell
    {
        public CellType Type { get; set; }
        public Trap? Trap { get; set; }
        public Obstacle? Obstacle { get; set; }
        public Cell(CellType type, Trap? trap = null, Obstacle? obstacle = null)
        {
            Type = type;
            Trap = trap;
            Obstacle = obstacle;
        }

        public string GetCellType()
        {
            return Type switch
            {
                CellType.Wall => "Wall",
                CellType.Road => "Road",
                CellType.Trap => "Trap",
                CellType.Obstacle => "Obstacle",
                CellType.Exit => "Exit",
                _ => "Unknown"
            };
        }
    }

    public enum CellType
    {
        Road, Wall, Trap, Obstacle, Exit
    }

    public Labyrinth(int width, int height)
    {
        Maze = new Cell[height, width];
        MazeAlgorithm.GenerateMaze(this);
    }

    public void CheckAndActivateTrap(Player player)
    {
        var cell = Maze[player.Position.RowPosition, player.Position.ColPosition];
        if (cell.GetCellType() == "Trap")
        {
            cell.Trap?.Activate(player);
        }
    }
}

