using AnimeMaze.Models;
using AnimeMaze.Services;
using System;
using System.Collections.Generic;

namespace AnimeMaze.Data;

public static class TrapData
{
    public static List<Trap> Traps = new List<Trap>
    {
        new Trap(
            "Trampa de Veneno",
            "Un gas venenoso del anime 'Naruto' que reduce la salud del jugador en 20 puntos.",
            "/images/green-smoke.png",
            player => player.Health -= 20
        ),
        new Trap(
            "Trampa de Parálisis",
            "Electricidad del 'Raikiri' del anime 'Bleach' que inmoviliza al jugador por un turno.",
            "/images/electricity.jpeg",
            player =>
            {
                if (player.HeroSelected != null )
                {
                    player.AddTemporaryEffect(new TemporaryEffect(
                        "Parálisis",
                        p => p.Speed = 0,
                        p => p.Speed = p.HeroSelected.Speed, // Revertir velocidad a su valor original
                        1 // Cambiamos a 1 turno para hacer pruebas
                    ));
                    TurnManager.MovesLeft = 0; // Actualiza MovesLeft
                    TurnManager.NextTurn();
                }
            }
        ),
        new Trap(
            "Trampa de Rc Cells",
            "Una explosión de Rc Cells del anime 'Tokyo Ghoul' que reduce la salud del jugador en 15 puntos y su velocidad en 1 punto durante 3 turnos.",
            "/images/rc-cells.jpeg",
            player =>
            {
                player.Health -= 15;
                if (player.HeroSelected != null)
                {
                    player.AddTemporaryEffect(new TemporaryEffect(
                        "Rc Cells",
                        p => p.Speed = Math.Max(p.Speed - 1, 0), // Reducir velocidad en 1, sin permitir valores negativos
                        p => p.Speed = p.HeroSelected.Speed, // Revertir el efecto
                        3
                    ));
                    TurnManager.MovesLeft--; // Ajusta MovesLeft
                    if (TurnManager.MovesLeft <= 0) 
                    {
                        TurnManager.NextTurn(); 
                    }
                }
            }
        )
    };
}
