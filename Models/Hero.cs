namespace AnimeMaze.Models;

public class Hero
{
    private int _speed;
    private int _health;
    private int _attack;

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public HeroImage Image { get; set; } = new HeroImage();
    public Power Power { get; set; } = new Power("Default", "Description", 0, (player, players) => {});


    public int Speed
    {
        get => _speed;
        set
        {
            if (value < 0 || value > 5)
                throw new ArgumentOutOfRangeException(nameof(Speed), "Speed must be between 0 and 5.");
            _speed = value;
        }
    }

    public int Health
    {
        get => _health;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(Health), "Health must be between 0 and 100.");
            _health = value;
        }
    }

    public int Attack
    {
        get => _attack;
        set
        {
            if (Name != "Saitama" && (value < 0 || value > 40))
                throw new ArgumentOutOfRangeException(nameof(Attack), "Attack must be between 0 and 40 for all heroes except Saitama.");
            if (Name == "Saitama" && (value < 0 || value > 100))
                throw new ArgumentOutOfRangeException(nameof(Attack), "Attack must be between 0 and 100 for Saitama.");
            _attack = value;
        }
    }

    public Hero(string name, string description, int speed, int health, int attack, Power power)
    {
        Name = name;
        Description = description;
        Image = new HeroImage(name);
        Speed = speed;
        Health = health;
        Attack = attack;
        Power = power;
    }

    public Hero() {}
}
