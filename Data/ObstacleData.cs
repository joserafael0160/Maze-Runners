using AnimeMaze.Models;
using System.Collections.Generic;

namespace AnimeMaze.Data;

public static class ObstacleData
{
  private static readonly Random random = new();

  private static readonly List<(int Health, string Name, string Image)> ObstacleDefinitions =
  [
    (100, "Rock", "/images/Obstacles/Rock.png"),
  ];

  public static Obstacle CreateRandomObstacle()
  {
    var obstacleDefinition = ObstacleDefinitions[random.Next(ObstacleDefinitions.Count)];
    return new Obstacle(obstacleDefinition.Health, obstacleDefinition.Name, obstacleDefinition.Image);
  }

  public static void ResetObstacles(Labyrinth labyrinth)
  {
    foreach (var cell in labyrinth.Maze)
    {
      cell.Obstacle?.Reset();
    }
  }
}
