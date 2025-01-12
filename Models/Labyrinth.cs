using AnimeMaze.Data;
using System.Linq;

namespace AnimeMaze.Models;

public class Labyrinth
{
    public Cell[,] Maze { get; }

    public class Cell
    {
        public CellType Type { get; set; }
        public Trap? Trap { get; set; }

        public Cell(CellType type, Trap? trap = null)
        {
            Type = type;
            Trap = trap;
        }

        // Método para obtener el tipo de celda
        public string GetCellType()
        {
            return Type switch
            {
                CellType.Wall => "Wall",
                CellType.Road => "Road",
                CellType.Trap => "Trap",
                CellType.Exit => "Exit",
                _ => "Unknown"
            };
        }
    }

    public enum CellType
    {
        Road, Wall, Trap, Exit
    }

    public Labyrinth()
    {
        Maze = new Cell[,]
        {
            { new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Trap, TrapData.Traps[1]), new Cell(CellType.Trap, TrapData.Traps[1]), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Trap, TrapData.Traps[0]), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Trap, TrapData.Traps[2]), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Trap, TrapData.Traps[2]), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall) },
            { new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Wall), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Road), new Cell(CellType.Exit) },
            { new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall), new Cell(CellType.Wall) }
        };
    }

    // Método para comprobar y activar las trampas
    public void CheckAndActivateTrap(Player player)
    {
        var cell = Maze[player.Position.RowPosition, player.Position.ColPosition];
        if (cell.GetCellType() == "Trap")
        {
            cell.Trap?.Activate(player);
        }
    }
}
