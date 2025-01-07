namespace AnimeMaze.Models;

public class Hero
{
    private int _speed;
    private int _life;
    private int _attack;

    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public List<string> Powers { get; set; } = new List<string>();

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

    public int Life
    {
        get => _life;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(Life), "Life must be between 0 and 100.");
            _life = value;
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

    public Hero(string name, string description, string image, int speed, int life, int attack, List<string> powers)
    {
        Name = name;
        Description = description;
        Image = image;
        Speed = speed;
        Life = life;
        Attack = attack;
        Powers = powers ?? new List<string>();
    }

    public Hero() {}  
}
