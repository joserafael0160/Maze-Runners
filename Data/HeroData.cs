using AnimeMaze.Models;
using System.Collections.Generic;

namespace AnimeMaze.Data;

public static class HeroData
{
    public static List<Hero> HeroCharacters = new List<Hero>
    {
        new Hero(
            "Kaneki", 
            "Inicialmente un estudiante universitario normal, su vida cambia drásticamente cuando es transformado en mitad ghoul tras un accidente. Kaneki lucha por adaptarse a su nueva identidad y mantener su humanidad.", 
            "/images/kaneki.jpeg"
        ),
        new Hero(
            "Eren Yeager", 
            "Determinado a destruir a los titanes que amenazan a la humanidad, Eren descubre sus habilidades como titán cambiante y se convierte en una figura clave en la lucha por la supervivencia.", 
            "/images/eren.jpeg"
        ),
        new Hero(
            "Goku", 
            "Un guerrero Saiyajin que busca constantemente desafíos y entrenamientos para convertirse en el ser más fuerte del universo. Su carácter amable y protector lo lleva a defender la Tierra de diversas amenazas.", 
            "/images/goku.jpeg"
        ),
        new Hero(
            "Naruto Uzumaki", 
            "Marcado desde pequeño como un paria por tener al zorro de nueve colas sellado dentro de él, Naruto sueña con convertirse en Hokage, el líder y protector de su aldea.",
            "/images/naruto.jpeg"
        ),
        new Hero(
            "Monkey D. Luffy", 
            "Es un joven pirata con el sueño de encontrar el One Piece y convertirse en el Rey de los Piratas. Luffy tiene la habilidad de estirarse como goma gracias a la fruta del diablo que comió.",
            "/images/luffy.jpeg"
        ),
        new Hero(
            "Jinx", 
            "Conocida por su amor al caos y la destrucción, Jinx es una criminal temida en Piltover. Su personalidad impredecible y su arsenal de armas locas la hacen una fuerza a tener en cuenta.",
            "/images/jinx.jpeg"
        ),
        new Hero(
            "Saitama", 
            "Conocido como el héroe por diversión, Saitama tiene una fuerza abrumadora que le permite derrotar a cualquier enemigo de un solo golpe.",
            "/images/saitama.jpeg"
        ),
        new Hero(
            "Shinji Ikari", 
            "Un adolescente inseguro y con problemas emocionales, es reclutado para pilotar un Evangelion y luchar contra misteriosas criaturas conocidas como Ángeles.",
            "/images/shingi.jpg"
        )
    };
}
