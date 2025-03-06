namespace AnimeMaze.Data;

public class Obstacle
{
    public int Health { get; private set; }
    public int MaxHealth { get; private set; }
    public string Image { get; set; }
    public string Name { get; set; }

    public Obstacle(int health, string name, string image)
    {
        Health = health;
        MaxHealth = health;
        Image = image;
        Name = name;
    }

    public void TakeDamage(int damage)
    {
        if (Health > 0)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }
    }

    public bool IsBroken()
    {
        return Health <= 0;
    }

    public void Reset()
    {
        Health = MaxHealth;
    }
}
