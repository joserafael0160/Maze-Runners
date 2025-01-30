using AnimeMaze.Models;
namespace AnimeMaze.Data;

public static class LabyrinthData
{
    public static int SelectedSize { get; set; } = 15; // Tamaño por defecto
    public static Labyrinth Game { get; private set; } = new Labyrinth(SelectedSize, SelectedSize);

    public static void ResetLabyrinth()
    {
        Game = new Labyrinth(SelectedSize, SelectedSize);
        // Resto del código...
    }
}
