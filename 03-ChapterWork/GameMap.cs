using System.Text;
namespace Chapter3;

public class GameMap
{
    public static void Demo()
    {
        char[,] map =
        {
            {'s', 's', 's', 'g', 'g', 'g', 'g', 'g'},
            {'s', 's', 's', 'g', 'g', 'g', 'g', 'g'},
            {'s', 's', 's', 's', 's', 'b', 'b', 'b'},
            {'s', 's', 's', 's', 's', 'b', 's', 's'},
            {'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w'},
            {'w', 'w', 'w', 'w', 'w', 'b', 'w', 'w'}
        };
    
        Console.OutputEncoding = Encoding.UTF8;
    
        for (int r = 0; r < map.GetLength(0); r++)
        {
            for (int c = 0; c < map.GetLength(1); c++)
            {
                Console.ForegroundColor = GetColor(map[r, c]);
                Console.Write(GetChar(map[r,c]) + " ");
            }
            Console.WriteLine();
        }
        Console.ResetColor();

    }
    
    static ConsoleColor GetColor(char terrain)
    {
        return terrain switch
        {
            'g' => ConsoleColor.Green,
            's' => ConsoleColor.Yellow,
            'w' => ConsoleColor.Blue,
             _  => ConsoleColor.DarkGray
        };
    }

    static char GetChar(char terrain)
    {
        return terrain switch
        {
            'g' => '\u201c',
            's' => '\u25cb',
            'w' => '\u2248',
             _  => '\u25cf'
        };
    }

}