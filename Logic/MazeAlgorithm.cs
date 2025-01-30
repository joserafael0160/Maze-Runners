namespace AnimeMaze.Logic;

using System;
using System.Collections.Generic;
using AnimeMaze.Models;
using AnimeMaze.Data;

public static class MazeAlgorithm
{
    private static readonly Random random = new Random();

    public static void GenerateMaze(Labyrinth labyrinth)
    {
        int width = labyrinth.Maze.GetLength(1);
        int height = labyrinth.Maze.GetLength(0);
        List<(int x, int y)> walls = new List<(int, int)>();

        InitializeMaze(labyrinth, width, height);

        int startX = GetRandomOddNumber(width);
        int startY = GetRandomOddNumber(height);
        labyrinth.Maze[startY, startX].Type = Labyrinth.CellType.Road;

        int counter = random.Next(4, 15);

        walls.Add((startX, startY));
        while (walls.Count > 0)
        {
            int index = random.Next(walls.Count);
            var (currentX, currentY) = walls[index];
            walls.RemoveAt(index);

            AddNeighboringWalls(currentX, currentY, walls, labyrinth, width, height, ref counter);
        }
        PlaceExit(labyrinth, width, height, out int exitX, out int exitY);
        var furthestPositions = FindFurthestPositions(labyrinth, width, height, exitX, exitY);
        PlayerData.InitialPositions = furthestPositions;
    }

    private static void AddNeighboringWalls(int x, int y, List<(int, int)> walls, Labyrinth labyrinth, int width, int height, ref int counter)
    {
        int[] dx = { -2, 2, 0, 0 };
        int[] dy = { 0, 0, -2, 2 };
        int[] dx1 = { -1, 1, 0, 0 };
        int[] dy1 = { 0, 0, -1, 1 };

        for (int i = 0; i < 4; i++)
        {
            int nx = x + dx[i];
            int ny = y + dy[i];
            int intermediateX = dx1[i] + x;
            int intermediateY = dy1[i] + y;
            if (IsWithinBounds(nx, ny, width, height) && labyrinth.Maze[ny, nx].Type == Labyrinth.CellType.Wall)
            {
                labyrinth.Maze[intermediateY, intermediateX].Type = Labyrinth.CellType.Road;
                labyrinth.Maze[ny, nx].Type = Labyrinth.CellType.Road;
                counter--;

                if (counter == 0)
                {
                    if (random.Next(2) == 0)
                    {
                        var trap = TrapData.Traps[random.Next(TrapData.Traps.Count)]; 
                        labyrinth.Maze[ny, nx].Trap = trap; 
                        labyrinth.Maze[ny, nx].Type = Labyrinth.CellType.Trap;
                    }
                    else
                    {
                        var obstacle = ObstacleData.CreateRandomObstacle(); 
                        labyrinth.Maze[ny, nx].Obstacle = obstacle; 
                        labyrinth.Maze[ny, nx].Type = Labyrinth.CellType.Obstacle;
                    }
                    counter = random.Next(4, 8);
                }

                walls.Add((nx, ny));
            }
        }
    }

    private static int GetRandomOddNumber(int max)
    {
        int number = random.Next(1, max - 1);
        return number % 2 == 0 ? number + 1 : number;
    }

    private static bool IsWithinBounds(int x, int y, int width, int height)
    {
        return x > 0 && x < width - 1 && y > 0 && y < height - 1;
    }

    private static void InitializeMaze(Labyrinth labyrinth, int width, int height)
    {
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                labyrinth.Maze[y, x] = new Labyrinth.Cell(Labyrinth.CellType.Wall);
            }
        }
    }

    private static void PlaceExit(Labyrinth labyrinth, int width, int height, out int exitX, out int exitY)
    {
        int border = random.Next(4);

        switch (border)
        {
            case 0: // Top Border
                exitX = GetRandomOddNumber(width);
                exitY = 0;
                break;
            case 1: // Bottom Border
                exitX = GetRandomOddNumber(width);
                exitY = height - 1;
                break;
            case 2: // Left Border
                exitX = 0;
                exitY = GetRandomOddNumber(height);
                break;
            default: // Right Border
                exitX = width - 1;
                exitY = GetRandomOddNumber(height);
                break;
        }

        labyrinth.Maze[exitY, exitX].Type = Labyrinth.CellType.Exit;
    }

    public static List<(int row, int col)> FindFurthestPositions(Labyrinth labyrinth, int width, int height, int startX, int startY)
    {
        var directions = new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) };
        var visited = new bool[height, width];
        var queue = new Queue<(int row, int col, int dist)>();
        var allPositions = new List<(int row, int col, int dist)>();
        var random = new Random();
    
        queue.Enqueue((startY, startX, 0));
        visited[startY, startX] = true;
    
        while (queue.Count > 0)
        {
            var (currentRow, currentCol, distance) = queue.Dequeue();
    
            foreach (var (dx, dy) in directions)
            {
                int newRow = currentRow + dx;
                int newCol = currentCol + dy;
    
                if (IsWithinBounds(newCol, newRow, width, height) && 
                    !visited[newRow, newCol] && 
                    labyrinth.Maze[newRow, newCol].Type != Labyrinth.CellType.Wall)
                {
                    visited[newRow, newCol] = true;
                    queue.Enqueue((newRow, newCol, distance + 1));
                    if (labyrinth.Maze[newRow, newCol].Type == Labyrinth.CellType.Road)
                    {
                        allPositions.Add((newRow, newCol, distance + 1)); // Corregido distance
                    }
                }
            }
        }
    
        // Ordenar y asegurar mínimo 4 posiciones
        var furthestPositions = allPositions
            .OrderByDescending(p => p.dist)
            .Select(p => (p.row, p.col))
            .ToList();
    
        // Rellenar con posiciones aleatorias si no hay suficientes
        while (furthestPositions.Count < 4)
        {
            int row = random.Next(1, height - 1);
            int col = random.Next(1, width - 1);
            
            if (labyrinth.Maze[row, col].Type == Labyrinth.CellType.Road &&
                !furthestPositions.Contains((row, col)))
            {
                furthestPositions.Add((row, col));
            }
        }
    
        return furthestPositions.Take(4).ToList();
    }
}
