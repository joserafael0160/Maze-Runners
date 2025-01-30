using AnimeMaze.Models;

namespace AnimeMaze.Data;

public static class HeroData
{
    public static List<Hero> HeroCharacters = new List<Hero>
    {
        new Hero(
            "Kaneki", 
            "Inicialmente un estudiante universitario normal, su vida cambia drásticamente cuando es transformado en mitad ghoul tras un accidente. Kaneki lucha por adaptarse a su nueva identidad y mantener su humanidad mientras enfrenta los desafíos de ser un ghoul en un mundo que lo rechaza.", 
            4, 
            70, 
            35,
            new Power(
                "Regeneración", 
                "Kaneki activa su habilidad de regeneración rápida, recuperando 20 puntos de salud inmediatamente. Esta habilidad es esencial para mantenerse en combates prolongados.", 
                2, 
                (player, players) => 
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
            "Determinado a destruir a los titanes que amenazan a la humanidad, Eren descubre sus habilidades como titán cambiante y se convierte en una figura clave en la lucha por la supervivencia. Su determinación y fuerza lo convierten en un líder natural.", 
            5, 
            80, 
            38,
            new Power(
                "Ataque Titán", 
                "Eren se transforma en el Titán de Ataque y realiza tres golpes devastadores consecutivos, causando daño masivo a todos los enemigos en su camino.", 
                3, 
                (player, players) => 
                {
                    for (int i = 0; i < 3; i++)
                    {
                        player.AttackTarget();
                    }
                })
        ),
        new Hero(
            "Goku", 
            "Un guerrero Saiyajin que busca constantemente desafíos y entrenamientos para convertirse en el ser más fuerte del universo. Su carácter amable y protector lo lleva a defender la Tierra de diversas amenazas, siempre buscando superar sus límites.", 
            5, 
            100, 
            40,
            new Power(
                "Kamehameha", 
                "Goku carga su energía y lanza un poderoso Kamehameha, un rayo de energía que golpea dos veces y atraviesa a los enemigos con una fuerza abrumadora.", 
                3, 
                (player, players) => 
                {
                    for (int i = 0; i < 2; i++)
                    {
                        player.AttackTarget();
                    }
                })
        ),
        new Hero(
            "Naruto Uzumaki", 
            "Marcado desde pequeño como un paria por tener al zorro de nueve colas sellado dentro de él, Naruto sueña con convertirse en Hokage, el líder y protector de su aldea. Su perseverancia y espíritu indomable lo convierten en un héroe inspirador.", 
            4, 
            80, 
            32,
            new Power(
                "Rasengan", 
                "Naruto crea una esfera de chakra giratoria en su mano y la lanza contra su enemigo, golpeando dos veces con un impacto devastador que desequilibra a sus oponentes.", 
                3, 
                (player, players) => 
                {
                    for (int i = 0; i < 2; i++)
                    {
                        player.AttackTarget();
                    }
                })
        ),
        new Hero(
            "Monkey D. Luffy", 
            "Es un joven pirata con el sueño de encontrar el One Piece y convertirse en el Rey de los Piratas. Luffy tiene la habilidad de estirarse como goma gracias a la fruta del diablo que comió, lo que lo convierte en un luchador impredecible y poderoso.", 
            4, 
            70, 
            34,
            new Power(
                "Gomu Gomu no Mi", 
                "Luffy utiliza su elasticidad para realizar un combo rápido de tres ataques consecutivos, golpeando a sus enemigos con una velocidad y fuerza increíbles.", 
                2, 
                (player, players) => 
                {
                    for (int i = 0; i < 3; i++)
                    {
                        player.AttackTarget();
                    }
                })
        ),
        new Hero(
            "Saitama", 
            "Conocido como el héroe por diversión, Saitama tiene una fuerza abrumadora que le permite derrotar a cualquier enemigo de un solo golpe. A pesar de su increíble poder, busca desesperadamente un desafío que lo haga sentir emocionado nuevamente.", 
            5, 
            100, 
            100,
            new Power(
                "Puñetazo serio", 
                "Saitama lanza un puñetazo con una fuerza inimaginable, capaz de derrotar a cualquier enemigo en un solo golpe. Este ataque es tan poderoso que no necesita combinaciones ni trucos.", 
                2, 
                (player, players) => 
                {
                    player.AttackTarget(); 
                })
        )
    };
}