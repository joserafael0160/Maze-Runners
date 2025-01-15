using AnimeMaze.Models;

namespace AnimeMaze.Data;

public static class HeroData
{
    public static List<Hero> HeroCharacters = new List<Hero>
    {
        new Hero(
            "Kaneki", 
            "Inicialmente un estudiante universitario normal, su vida cambia drásticamente cuando es transformado en mitad ghoul tras un accidente. Kaneki lucha por adaptarse a su nueva identidad y mantener su humanidad.", 
            "/images/kaneki.jpeg",
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
            "/images/eren.jpeg",
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
            "/images/goku.jpeg",
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
            "/images/naruto.jpeg",
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
            "/images/luffy.jpeg",
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
            "Jinx", 
            "Conocida por su amor al caos y la destrucción, Jinx es una criminal temida en Piltover. Su personalidad impredecible y su arsenal de armas locas la hacen una fuerza a tener en cuenta.",
            "/images/jinx.jpeg",
            3, 
            50, 
            30,
            new Power("Super Mega Death Rocket", 4, (player, players) => 
            {
                for (int i = 0; i < 2; i++)
                {
                    player.AttackTarget();
                }
            })
        ),
        new Hero(
            "Saitama", 
            "Conocido como el héroe por diversión, Saitama tiene una fuerza abrumadora que le permite derrotar a cualquier enemigo de un solo golpe.",
            "/images/saitama.jpeg",
            5, 
            100, 
            100,
            new Power("Puñetazo serio", 2, (player, players) => 
            {
                player.AttackTarget(); 
            })
        ),
        new Hero(
            "Shinji Ikari", 
            "Un adolescente inseguro y con problemas emocionales, es reclutado para pilotar un Evangelion y luchar contra misteriosas criaturas conocidas como Ángeles.",
            "/images/shingi.jpg",
            2, 
            40, 
            20,
            new Power("Lanza de Longinus", 4, (player, players) => 
            {
                for (int i = 0; i < 2; i++) 
                {
                    player.AttackTarget();
                }
            })
        ), 
        new Hero(
            "Nana Osaki", 
            "Una talentosa cantante de punk rock con un espíritu independiente y fuerte.", 
            "/images/nana_osaki.jpeg",
            3, 
            60, 
            25,
            new Power("Voz Poderosa", 2, (player, players) => 
            {
                for (int i = 0; i < 2; i++) 
                {
                    player.AttackTarget();
                }
            })
        ),
        new Hero(
            "Ichigo Kurosaki", 
            "Un adolescente con la capacidad de ver fantasmas y un poder espiritual inmenso que le permite convertirse en un Shinigami.", 
            "/images/ichigo_kurosaki.jpeg",
            4, 
            80, 
            36,
            new Power("Getsuga Tensho", 2, (player, players) => 
            {
                for (int i = 0; i < 2; i++) 
                {
                    player.AttackTarget();
                }
            })
        ),
        new Hero(
            "Punpun", 
            "Un personaje complejo y simbólico de la serie 'Oyasumi Punpun'.", 
            "/images/punpun.png",
            1, 
            10, 
            1,
            new Power("Inocencia Desgarradora", 3, (player, players) => 
            {
                for (int i = 0; i < 2; i++) 
                {
                    player.AttackTarget();
                }
            })
        )
    };
}
