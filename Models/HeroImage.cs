namespace AnimeMaze.Models;

public class HeroImage
{
  public string Down { get; set; } = string.Empty;
  public string Up { get; set; } = string.Empty;
  public string Left { get; set; } = string.Empty;
  public string Right { get; set; } = string.Empty;

  public HeroImage(string name)
  {
    Down = $"images/Characters/{name}/Down.png";
    Up = $"images/Characters/{name}/Up.png";
    Left = $"images/Characters/{name}/Left.png";
    Right = $"images/Characters/{name}/Right.png";
  }

  public HeroImage() { }
}
