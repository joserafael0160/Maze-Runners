namespace AnimeMaze.Models;

public class Player
{
    public (int RowPosition, int ColPosition) Position { get; set; }
    public Hero? HeroSelected { get; set; }

    public Player((int row, int col) position)
    {
        Position = position;
    }

}

 