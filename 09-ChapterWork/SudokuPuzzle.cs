namespace Chapter9;

public class SudokuPuzzle
{
    public static int[,] Board = new int[,]
    {
        { 0, 5, 0, 4, 0, 1, 0, 0, 6 },
        { 1, 0, 0, 9, 5, 0, 8, 0, 0 },
        { 9, 0, 4, 0, 6, 0, 0, 0, 1 },
        { 6, 2, 0, 0, 0, 5, 3, 0, 4 },
        { 0, 9, 0, 0, 7, 0, 2, 0, 5 },
        { 5, 0, 7, 0, 0, 0, 0, 8, 9 },
        { 8, 0, 0, 5, 1, 9, 0, 0, 2 },
        { 2, 3, 0, 0, 0, 6, 5, 0, 8 },
        { 4, 1, 0, 2, 0, 8, 6, 0, 0 }
    };

    public static void Demo()
    {
        if (Solve()) {Print();}
    }

    public static bool Solve()
    {
        (var row, var col) = GetEmpty();
        if (row < 0 && col < 0) {return true;}

        for (var i = 1; i <= 9; i++)
        {
            if (IsCorrect(row, col, i))
            {
                Board[row, col] = i;
                if (Solve()) {return true;}
                else {Board[row, col] = 0;}
            }
        }

        return false;
    }

    public static (int, int) GetEmpty()
    {
        for (var r = 0; r < 9; r++)
        {
            for (var c = 0; c < 9; c++)
            {
                if (Board[r, c] == 0) {return (r, c);}
            }
        }

        return (-1, -1);
    }

    public static bool IsCorrect(int row, int col, int num)
    {
        for (var i = 0; i < 9; i++)
        {
            if (Board[row, i] == num) {return false;}
            if (Board[i, col] == num) {return false;}
        }

        var rs = row - row % 3;
        var cs = col - col % 3;
        for (var r = rs; r < rs + 3; r++)
        {
            for (var c = cs; c < cs + 3; c++)
            {
                if (Board[r, c] == num) {return false;}
            }
        }

        return true;
    }

    public static void Print()
    {
        for (var r = 0; r < 9; r++)
        {
            for (var c = 0; c < 9; c++)
            {
                Console.Write($" {Board[r, c]} ");
            }
            Console.WriteLine();
        }
    }
}