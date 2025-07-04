namespace Chapter9;

public class RatInMaze
{
    const int size = 8;
    const bool t = true;
    const bool f = false;
    static bool[,] solution = new bool[size, size];
    static bool[,] maze =
    {
        { t, f, t, f, f, t, t, t },
        { t, t, t, t, t, f, t, f },
        { t, t, f, t, t, f, t, t },
        { f, t, t, f, t, f, f, t },
        { f, t, t, t, t, t, t, t },
        { t, f, t, f, t, f, f, t },
        { t, t, t, t, t, t, t, t },
        { f, t, f, f, f, t, f, t }
    };

    public static void Demo()
    {
        if (Go(0, 0)) {Print();}
    }


    static bool Go(int row, int col)
    {
        if (row == size - 1 && col == size - 1 && maze[row, col])
        {
            solution[row, col] = true;
            return true;
        }

        if (row >= 0 && row < size && col >= 0 && col < size && maze[row, col])
        {
            if (solution[row, col]) {return false;}

            solution[row, col] = true;
            if (Go(row + 1, col)) {return true;}
            if (Go(row, col + 1)) {return true;}
            if (Go(row - 1, col)) {return true;}
            if (Go(row, col - 1)) {return true;}

            solution[row, col] = false;
            return false;
        }

        return false;
    }

    static void Print()
    {
        for (var row = 0; row < size; row++)
        {
            for (var col = 0; col < size; col++)
            {
                Console.Write(solution[row, col] ? " x " : " - ");
            }
            Console.WriteLine();
        }
    }
}