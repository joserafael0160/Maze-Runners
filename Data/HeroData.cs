using AnimeMaze.CustomComponents;
using AnimeMaze.Models;
using AnimeMaze.Services;

namespace AnimeMaze.Data;

public static class HeroData
{
  public static List<Hero> HeroCharacters =
  [
    new Hero(
      "Kaneki",
      "Inicialmente un estudiante universitario normal, su vida cambia drásticamente cuando es transformado en mitad ghoul tras un accidente. Kaneki lucha por adaptarse a su nueva identidad y mantener su humanidad mientras enfrenta los desafíos de ser un ghoul en un mundo que lo rechaza.",
      4,
      70,
      35,
      new Power(
        "Kagune Devorador",
        "Despliega tentáculos afilados que dañan en área y roban vida",
        3,
        static (player, players) =>
        {
          // Daño en área 3x3
          for(int dr = -1; dr <= 1; dr++)
          {
            for(int dc = -1; dc <= 1; dc++)
            {
              int row = player.Position.RowPosition + dr;
              int col = player.Position.ColPosition + dc;

              var cell = ValidationService.GetCell(row, col);
              if(cell == null) continue;

              // Dañar jugadores
              var target = ValidationService.GetPlayerAtPosition(row, col);
              if(target != null && target != player)
              {
                int damage = 25;
                target.Health -= damage;
                if(player.HeroSelected != null)
                  player.Health = Math.Min(player.Health + (damage / 2), player.HeroSelected.Health);
              }
              if (target != null && target.Health <= 0)
              {
                target.Position = target.InitialPosition;
                target.InitializeStats();
              }
            }
          }
        }
      )
    ),
    new Hero(
      "Eren Yeager",
      "Determinado a destruir a los titanes que amenazan a la humanidad, Eren descubre sus habilidades como titán cambiante y se convierte en una figura clave en la lucha por la supervivencia. Su determinación y fuerza lo convierten en un líder natural.",
      5,
      80,
      38,
      new Power(
        "Titán Fundador",
        "Transformación que destruye todas las paredes adyacentes y aturde enemigos",
        4,
        (player, players) =>
        {
          (int row, int col) = player.Position;


          var game = LabyrinthData.Game;

          // Romper paredes en área 3x3
          for(int dr = -1; dr <= 1; dr++) {
            for(int dc = -1; dc <= 1; dc++) {
              if (row + dr < 1 || col + dc < 1 || row + dr >= game.Maze.GetLength(0) - 1 || col + dc >= game.Maze.GetLength(1) - 1) continue;
              var cell = ValidationService.GetCell(
                player.Position.RowPosition + dr,
                player.Position.ColPosition + dc
              );

              if(cell?.Type == Labyrinth.CellType.Wall) {
                cell.Type = Labyrinth.CellType.Road;
              }
              foreach(var p in players.Where(p => (p.Position == (row + dr, col + dc)) && p != player))
              {
                p.AddTemporaryEffect(new TemporaryEffect(
                  "Aturdido",
                  target => target.Speed /= 2,
                  target => target.Speed *= 2,
                  2
                ));
              }
            }
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
        "Teletransporte",
        "Teletransporta a Goku 6 casillas hacia la direccion que esté mirando y aumento de velocidad",
        4,
        (player, players) =>
        {
          var direction = player.FacingDirection;
          (int newRow, int newCol) = direction switch
          {
            Direction.Up => (player.Position.RowPosition - 6, player.Position.ColPosition),
            Direction.Down => (player.Position.RowPosition + 6, player.Position.ColPosition),
            Direction.Left => (player.Position.RowPosition, player.Position.ColPosition - 6),
            Direction.Right => (player.Position.RowPosition, player.Position.ColPosition + 6),
            _ => player.Position
          };

            // Verificar límites del laberinto
          if (ValidationService.IsValidMove(newRow, newCol))
          {
            player.Position = (newRow, newCol);
          }
          // Efecto secundario: Aumento temporal de velocidad
          player.AddTemporaryEffect(new TemporaryEffect(
            "Afterimage",
            p => p.Speed += 2,
            p => p.Speed -= 2,
            2
          ));
        })
    ),
    new Hero(
      "Naruto Uzumaki",
      "Marcado desde pequeño como un paria por tener al zorro de nueve colas sellado dentro de él, Naruto sueña con convertirse en Hokage, el líder y protector de su aldea. Su perseverancia y espíritu indomable lo convierten en un héroe inspirador.",
      4,
      80,
      32,
      new Power(
        "Modo Sabio",
        "Aumenta todas las estadísticas mediante el chakra natural",
        3,
        (player, players) =>
        {
          player.AddTemporaryEffect(new TemporaryEffect(
            "Modo Sabio",
            p => {
              p.Attack += 20;
              p.Speed += 3;
            },
            p => {
              p.Attack -= 20;
              p.Speed -= 3;
            },
            4
          ));
        })
    ),
    new Hero(
      "Monkey D. Luffy",
      "Es un joven pirata con el sueño de encontrar el One Piece y convertirse en el Rey de los Piratas. Luffy tiene la habilidad de estirarse como goma gracias a la fruta del diablo que comió, lo que lo convierte en un luchador impredecible y poderoso.",
      4,
      70,
      34,
      new Power(
        "Gear Second",
        "Aumenta velocidad y ataque, pero pierde salud",
        3,
        (player, players) =>
        {
          player.Health -= 10;
          if (player.Health <= 0)
          {
            player.Position = player.InitialPosition;
            player.InitializeStats();
          }
          player.AddTemporaryEffect(new TemporaryEffect(
            "Gear Second",
            p => {
              p.Speed += 2;
              p.Attack += 15;
            },
            p => {
              p.Speed -= 2;
              p.Attack -= 15;
            },
            3
          ));
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
        "Destruye TODO en lo que este en su camino",
        5,
        (player, players) =>
        {
          var direction = player.FacingDirection;
          int step = 0;
          var game = LabyrinthData.Game;

          while (true)
          {
            (int row, int col) = direction switch
            {
              Direction.Up => (player.Position.RowPosition - step, player.Position.ColPosition),
              Direction.Down => (player.Position.RowPosition + step, player.Position.ColPosition),
              Direction.Left => (player.Position.RowPosition, player.Position.ColPosition - step),
              Direction.Right => (player.Position.RowPosition, player.Position.ColPosition + step),
              _ => (-1, -1)
            };

            // Verificar límites
            if (row < 1 || col < 1 || row >= game.Maze.GetLength(0) - 1 || col >= game.Maze.GetLength(1) - 1) break;

            var cell = game.Maze[row, col];
            
            // Convertir paredes en camino
            cell.Type = Labyrinth.CellType.Road; // Cambiar tipo de celda
            
            
            // Destruir obstáculos y trampas
            cell.Obstacle = null;
            cell.Trap = null;
            
            // Dañar jugadores
            var targetPlayer = ValidationService.GetPlayerAtPosition(row, col);
            if (targetPlayer != null && targetPlayer != player)
            {
              targetPlayer.Health -= 200;
              if (targetPlayer.Health <= 0)
              {
                targetPlayer.Position = targetPlayer.InitialPosition;
                targetPlayer.InitializeStats();
              }
            }
            step++;
          }
        }
      )
    )
  ];
}
