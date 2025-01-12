namespace AnimeMaze.Models;

public class Power
{
    public string Name { get; set; } = string.Empty;
    public int Cooldown { get; set; }
    public int CurrentCooldown { get; set; } = 0;
    public Action<Player, List<Player>> Action { get; set; } = (_, _) => {};

    public Power(string name, int cooldown, Action<Player, List<Player>> action)
    {
        Name = name;
        Cooldown = cooldown;
        Action = action;
    }

    public Power() {}

    public void Use(Player player, List<Player> players)
    {
        if (CurrentCooldown == 0)
        {
            Action(player, players); // Ensure two parameters are passed here
            CurrentCooldown = Cooldown;
        }
    }

    public void ReduceCooldown()
    {
        if (CurrentCooldown > 0)
        {
            CurrentCooldown--;
        }
    }
}
