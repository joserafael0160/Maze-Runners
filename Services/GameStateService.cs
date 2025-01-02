namespace AnimeMaze;

public class GameStateService
{
    public Labyrinth Game { get; private set; }

    public GameStateService()
    {
        Game = new Labyrinth();
    }

    public void ResetGame()
    {
        Game = new Labyrinth();
    }
}
