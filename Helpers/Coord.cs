namespace NavalPlacementChallenge.Helpers;
public class Coord
{
    // fiels
    private int _x;
    private int _y;

    // Getters and Setters
    public int X
    {
        get => _x;
        set => _x = (value >= 1 && value <= 10) ? value : throw new ArgumentOutOfRangeException();
    }

    public int Y
    {
        get => _y;
        set => _y = (value >= 1 && value <= 10) ? value : throw new ArgumentOutOfRangeException();
    }

    // Contructor
    public Coord(string coord)
    {
        Y = coord[0] - '@'; // => se coloca de esta manera ya que el valor si es A deber ser 1
        X = Convert.ToInt32(coord[1..]);
    }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }

    // El problema no es claro con la distribucion del barco asi que asumimos que solo puede estar horizontal o vertical
    public int DistanceBetweenCoordinates(Coord coord)
    {
        int distanceX = Math.Abs(X - coord.X);
        int distanceY = Math.Abs(Y - coord.Y);

        if (distanceX == 0) return distanceY + 1;
        if (distanceY == 0) return distanceX + 1;

        throw new FormatException("El formato de coordinadas de origen destino no es valido");
    }

    public static Coord MaxCoord(Coord coord1, Coord coord2)
    {
        ArgumentNullException.ThrowIfNull(coord1, $"Error! {nameof(coord1)} no puede ser nulo");
        ArgumentNullException.ThrowIfNull(coord2, $"Error! {nameof(coord2)} no puede ser nulo");

        if (coord1.X == coord2.X)
            return coord1.Y > coord2.Y ? coord1 : coord2;

        if (coord1.Y == coord2.Y)
            return coord1.X > coord2.X ? coord1 : coord2;

        throw new FormatException("No cumple con coordinadas válidas");
    }

    public static Coord MinCoord(Coord coord1, Coord coord2)
    {
        ArgumentNullException.ThrowIfNull(coord1, $"Error! {nameof(coord1)} no puede ser nulo");
        ArgumentNullException.ThrowIfNull(coord2, $"Error! {nameof(coord2)} no puede ser nulo");

        if (coord1.X == coord2.X)
            return coord1.Y < coord2.Y ? coord1 : coord2;

        if (coord1.Y == coord2.Y)
            return coord1.X < coord2.X ? coord1 : coord2;

        throw new FormatException("No cumple con coordinadas válidas");
    }
}
