using AnimeMaze.Models;
namespace AnimeMaze.Data;

public static class LabyrinthData
{
    public static Labyrinth Game = new Labyrinth(11, 11);
    

    public static void ResetLabyrinth()
    {
        Game = new Labyrinth(11, 11);
        foreach (var cell in Game.Maze) 
        { 
            if (cell.Obstacle != null) 
            { 
                cell.Obstacle.Reset();
            }
        } 
    }
}
