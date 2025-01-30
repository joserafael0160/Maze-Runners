using AnimeMaze.Models;
namespace AnimeMaze.Data;

public static class LabyrinthData
{
    public static Labyrinth Game = new Labyrinth(9, 9);
    

    public static void ResetLabyrinth()
    {
        Game = new Labyrinth(9, 9);
        foreach (var cell in Game.Maze) 
        { 
            if (cell.Obstacle != null) 
            { 
                cell.Obstacle.Reset();
            }
        } 
    }
}
