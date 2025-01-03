namespace AnimeMaze.Models;

public class Hero
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }

    public Hero(string name, string description, string image)
    {
        Name = name;
        Description = description;
        Image = image;
    }
}

