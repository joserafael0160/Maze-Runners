using AnimeMaze.Models;

namespace AnimeMaze.Data;

public static class HeroData
{
    public static List<Hero> HeroCharacters = new List<Hero>
    {
        new Hero(
            "Kaneki", 
            "Inicialmente un estudiante universitario normal, su vida cambia drásticamente cuando es transformado en mitad ghoul tras un accidente. Kaneki lucha por adaptarse a su nueva identidad y mantener su humanidad.", 
            4, 
            70, 
            35,
            new Power("Regeneración", 2, (player, players) => 
            {
                player.Health += 20;
                if (player.Health > player.HeroSelected?.Health)
                {
                    player.Health = player.HeroSelected.Health;
                }
            })
        ),
        new Hero(
            "Eren Yeager", 
            "Determinado a destruir a los titanes que amenazan a la humanidad, Eren descubre sus habilidades como titán cambiante y se convierte en una figura clave en la lucha por la supervivencia.", 
            5, 
            80, 
            38,
            new Power("Ataque Titán", 3, (player, players) => 
            {
                for (int i = 0; i < 3; i++)
                {
                    player.AttackTarget();
                }
            })
        ),
        new Hero(
            "Goku", 
            "Un guerrero Saiyajin que busca constantemente desafíos y entrenamientos para convertirse en el ser más fuerte del universo. Su carácter amable y protector lo lleva a defender la Tierra de diversas amenazas.", 
            5, 
            100, 
            40,
            new Power("Kamehameha", 3, (player, players) => 
            {
                for (int i = 0; i < 2; i++)
                {
                    player.AttackTarget();
                }
            })
        ),
        new Hero(
            "Naruto Uzumaki", 
            "Marcado desde pequeño como un paria por tener al zorro de nueve colas sellado dentro de él, Naruto sueña con convertirse en Hokage, el líder y protector de su aldea.",
            4, 
            80, 
            32,
            new Power("Rasengan", 3, (player, players) => 
            {
                for (int i = 0; i < 2; i++)
                {
                    player.AttackTarget();
                }
            })
        ),
        new Hero(
            "Monkey D. Luffy", 
            "Es un joven pirata con el sueño de encontrar el One Piece y convertirse en el Rey de los Piratas. Luffy tiene la habilidad de estirarse como goma gracias a la fruta del diablo que comió.",
            4, 
            70, 
            34,
            new Power("Gomu Gomu no Mi", 2, (player, players) => 
            {
                for (int i = 0; i < 3; i++)
                {
                    player.AttackTarget();
                }
            })
        ),
        new Hero(
            "Saitama", 
            "Conocido como el héroe por diversión, Saitama tiene una fuerza abrumadora que le permite derrotar a cualquier enemigo de un solo golpe.",
            5, 
            100, 
            100,
            new Power("Puñetazo serio", 2, (player, players) => 
            {
                player.AttackTarget(); 
            })
        )
    };
}
