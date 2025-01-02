namespace AnimeMaze;

public class Labyrinth
{
    public int PlayerRow { get; set; } = 8;
    public int PlayerCol { get; set; } = 1;
    public Cell[,] Maze { get; }

    public enum Cell
    {
        Road, Wall, Trap, Exit
    }

    public Labyrinth()
    {
        Maze = new Cell[,]
        {
            { Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall },
            { Cell.Wall, Cell.Road, Cell.Road, Cell.Road, Cell.Road, Cell.Road, Cell.Road, Cell.Wall, Cell.Road, Cell.Wall },
            { Cell.Wall, Cell.Road, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Road, Cell.Wall, Cell.Road, Cell.Wall },
            { Cell.Wall, Cell.Road, Cell.Wall, Cell.Trap, Cell.Road, Cell.Road, Cell.Road, Cell.Wall, Cell.Road, Cell.Wall },
            { Cell.Wall, Cell.Road, Cell.Road, Cell.Road, Cell.Trap, Cell.Wall, Cell.Road, Cell.Wall, Cell.Road, Cell.Wall },
            { Cell.Wall, Cell.Wall, Cell.Wall, Cell.Road, Cell.Wall, Cell.Wall, Cell.Road, Cell.Wall, Cell.Road, Cell.Wall },
            { Cell.Wall, Cell.Road, Cell.Road, Cell.Road, Cell.Wall, Cell.Road, Cell.Road, Cell.Road, Cell.Road, Cell.Wall },
            { Cell.Wall, Cell.Road, Cell.Wall, Cell.Road, Cell.Wall, Cell.Road, Cell.Wall, Cell.Wall, Cell.Road, Cell.Wall },
            { Cell.Wall, Cell.Road, Cell.Wall, Cell.Road, Cell.Road, Cell.Road, Cell.Road, Cell.Road, Cell.Road, Cell.Exit },
            { Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall, Cell.Wall }
        };
    }
}
