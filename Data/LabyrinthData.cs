using AnimeMaze.Models;
namespace AnimeMaze.Data;

public static class LabyrinthData
{
    public static Labyrinth Game = new Labyrinth(21, 21);
    

    public static void ResetLabyrinth()
    {
        Game = new Labyrinth(21, 21);
        foreach (var cell in Game.Maze) 
        { 
            if (cell.Obstacle != null) 
            { 
                cell.Obstacle.Reset();
            }
        } 
    }
}
