using AnimeMaze.Models;
using System.Collections.Generic;

namespace AnimeMaze.Data;

public static class ObstacleData
{
    public static List<Obstacle> Obstacles = new List<Obstacle>
    {
        new Obstacle(100, "Rock", "/images/rock.jpg"),
    };

    public static void ResetObstacles()
    {
        foreach (var obstacle in Obstacles)
        {
            obstacle.Reset(); 
        }
    }
}
