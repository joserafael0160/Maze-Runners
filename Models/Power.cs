namespace AnimeMaze.Models;

public class Power
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Cooldown { get; set; }
    public int CurrentCooldown { get; set; } = 0;
    public Action<Player, List<Player>> Action { get; set; }

    public Power(string name, string description, int cooldown, Action<Player, List<Player>> action)
    {
        Name = string.Empty;
        Description = string.Empty;
        Cooldown = cooldown;
        Action = action;
    }

    public Power() {}

    public void Use(Player player, List<Player> players)
    {
        if (CurrentCooldown == 0)
        {
            Action(player, players);
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