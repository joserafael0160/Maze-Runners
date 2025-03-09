namespace AnimeMaze.Models;
public class Trap(string name, string description, string image, Action<Player> activate)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public string Image { get; set; } = image;
    public Action<Player> Activate { get; set; } = (player) =>
      {
          if (!player.TemporaryEffects.Any(e => e.Name == name))
          {
              activate(player);
              player.AddTemporaryEffect(new TemporaryEffect(
                    name,
                    p => { /* Aplicar efecto al inicio */ },
                    p => { /* Remover efecto al final */ },
                    0 // Duración en TURNOS COMPLETOS
                ));
          }
      };
}
