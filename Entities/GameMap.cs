namespace NavalPlacementChallenge.Entities;
public class GameMap
{
    private readonly string[,] _map =
    {
        {" ", "1","2", "3", "4", "5", "6", "7", "8", "9", "10"},
        {"A", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"B", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"C", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"D", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"E", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"F", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"G", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"H", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"I", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
        {"J", "~","~", "~", "~", "~", "~", "~", "~", "~", "~" },
    };


    public void Show()
    {
        for (int row = 0; row < _map.GetLength(0); row++)
        {
            for (int col = 0; col < _map.GetLength(1); col++)
            {
                Console.Write(_map[row, col].PadRight(3));
            }
            Console.WriteLine();
        }
    }

    public bool AvailableSpace(int row, int col)
    {
        if (row < 1 && row > 10) throw new ArgumentOutOfRangeException();
        if (col < 1 && col > 10) throw new ArgumentOutOfRangeException();

        return _map[row, col] != "O";
    }

    public void UpdateField(int row, int col)
    {
        _map[row, col] = "O";
    }
}
