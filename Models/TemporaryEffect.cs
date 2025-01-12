namespace AnimeMaze.Models;

public class TemporaryEffect
{
    public string Name { get; set; }
    public Action<Player> ApplyEffect { get; set; }
    public Action<Player> RemoveEffect { get; set; }
    public int TurnsRemaining { get; set; }

    public TemporaryEffect(string name, Action<Player> applyEffect, Action<Player> removeEffect, int duration)
    {
        Name = name;
        ApplyEffect = applyEffect;
        RemoveEffect = removeEffect;
        TurnsRemaining = duration;
    }

    public void Apply(Player player)
    {
        ApplyEffect(player);
    }

    public void Remove(Player player)
    {
        RemoveEffect(player);
    }

    public void DecrementTurn()
    {
    	if (TurnsRemaining > 0)
        {
            TurnsRemaining--;
        }
    }
}
