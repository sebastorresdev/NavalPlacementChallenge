using NavalPlacementChallenge.Entities;
using NavalPlacementChallenge.Helpers;

namespace NavalPlacementChallenge;
public class Game(string title, string description)
{
    private static readonly GameMap gameMap = new();

    private readonly string _title = title;
    private readonly string _description = description;
    
    public void Run(List<Ship> ships)
    {
        Console.WriteLine(_title);
        Console.WriteLine(_description);

        foreach (var ship in ships)
        {
            gameMap.Show();
            GetCoordinates(ship);
        }
        gameMap.Show();
        Console.WriteLine("!Fin del juego =)");
    }

    private static void GetCoordinates(Ship ship)
    {
        Console.WriteLine($"Enter the coordinates of the {ship.Name} ({ship.NumberCells} cells)");

        while (true)
        {
            Console.Write("> ");
            var input = Console.ReadLine() ?? "";

            var coords = input.Split(' ');
            if (coords.Length != 2)
            {
                Console.WriteLine("Error! el formato ingresado no es valido.");
                continue;
            }

            try
            {
                var coord1 = new Coord(coords[0]);
                var coord2 = new Coord(coords[1]);

                if (coord1.DistanceBetweenCoordinates(coord2) != ship.NumberCells)
                {
                    Console.WriteLine($"Error! el tamaño no coince con el de la celdas del {ship.Name}.");
                    continue;
                }

                if (!AvailablePosition(coord1, coord2))
                {
                    Console.WriteLine("Error! hay barcos adyancentes.");
                    continue;
                }

                PlaceBoat(coord1, coord2);
                break;
            }
            catch
            {
                Console.WriteLine("Error! ingreso no válido");
                continue;
            }
        }
    }

    private static bool AvailablePosition(Coord coord1, Coord coord2)
    {
        Coord coordiMin = Coord.MinCoord(coord1, coord2);
        Coord coordiMax = Coord.MaxCoord(coord1, coord2);

        for (int y = coordiMin.Y - 1; y <= coordiMax.Y + 1; y++)
        {
            for (int x = coordiMin.X - 1; x <= coordiMax.X + 1; x++)
            {
                try
                {
                    if (!gameMap.AvailableSpace(y, x)) return false;
                }
                catch { continue; }
            }
        }
        return true;
    }

    private static void PlaceBoat(Coord coord1, Coord coord2)
    {
        Coord coordiMin = Coord.MinCoord(coord1, coord2);
        Coord coordiMax = Coord.MaxCoord(coord1, coord2);

        for (int y = coordiMin.Y; y <= coordiMax.Y; y++)
        {
            for (int x = coordiMin.X; x <= coordiMax.X; x++)
            {
                gameMap.UpdateField(y, x);
            }
        }
    }
}
