using AnimeMaze.Models;
namespace AnimeMaze.Data;

public static class LabyrinthData
{
    public static Labyrinth Game = new Labyrinth(13, 13);
    

    public static void ResetLabyrinth()
    {
        Game = new Labyrinth(13, 13);
        foreach (var cell in Game.Maze) 
        { 
            if (cell.Obstacle != null) 
            { 
                cell.Obstacle.Reset();
            }
        } 
    }
}
