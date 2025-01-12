namespace AnimeMaze.Models;

public class Trap
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public Action<Player> Activate { get; set; }

    public Trap(string name, string description, string image, Action<Player> activate)
    {
        Name = name;
        Description = description;
        Image = image;
        Activate = (player) =>
        {
            if (!player.TemporaryEffects.Any(e => e.Name == name))
            {
                activate(player);
                player.AddTemporaryEffect(new TemporaryEffect(name, p => { }, p => { }, 1)); // Añadir efecto temporal vacío para evitar doble activación
            }
            if (player.Health <= 0)
            {
                player.Position = player.InitialPosition;
                player.InitializeStats();
            }
        };
    }
}
