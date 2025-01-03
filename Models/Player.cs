namespace AnimeMaze.Models;

public class Player
{
    public (int RowPosition, int ColPosition) Position { get; set; }
    public Hero? HeroSelected { get; set; }

    public Player(int rowPosition, int colPosition)
    {
        Position = (rowPosition, colPosition);
    }
}

 