using AnimeMaze.Models;
namespace AnimeMaze.Data;

public static class LabyrinthData
{
    public static Labyrinth Game = new Labyrinth();
    

    public static void ResetGame()
    {
        Game = new Labyrinth();
    }
}
