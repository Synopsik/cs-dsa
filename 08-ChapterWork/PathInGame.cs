using System.Text;
namespace Chapter8;

public class PathInGame
{
    public static void Demo()
    {
        string[] lines =
        [
            "0011100000111110000011111",
            "0011100000111110000011111",
            "0011100000111110000011111",
            "0000000000011100000011111",
            "0000001110000000000011111",
            "0001001110011100000011111",
            "1111111111111110111111100",
            "1111111111111110111111101",
            "1111111111111110111111100",
            "0000000000000000111111110",
            "0000000000000000111111100",
            "0001111111001100000001101",
            "0001111111001100000000000",
            "0001100000000000111111110",
            "1111100000000000111111100",
            "1111100011001100100010001",
            "1111100011001100001000100"
        ];
        var map = new bool[lines.Length][];
        
        for (var i = 0; i < lines.Length; i++)
        {
            // Search through each char in line index. Set member true if char == 0
            map[i] = lines[i].Select(c => int.Parse(c.ToString()) == 0).ToArray();
        }

        Graph<string> graph = new() { IsDirected = false, IsWeighted = true };

        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                if (!map[i][j]) {continue;}

                var from = graph.AddNode($"{i}-{j}");

                if (i > 0 && map[i - 1][j])
                {
                    var to = graph.Nodes.Find(n => n.Data == $"{i - 1}-{j}")!;
                    graph.AddEdge(from, to, 1);
                }

                if (j > 0 && map[i][j - 1])
                {
                    var to = graph.Nodes.Find(n => n.Data == $"{i}-{j - 1}")!;
                    graph.AddEdge(from, to, 1);
                }
            }
        }

        var s = graph.Nodes.Find(n => n.Data == "0-0")!;
        var t = graph.Nodes.Find(n => n.Data == "16-24")!;
        var path = graph.GetShortestPath(s, t);

        Console.OutputEncoding = Encoding.UTF8;
        for (var r = 0; r < map.Length; r++)
        {
            for (var c = 0; c < map[r].Length; c++)
            {
                var isPath = path.Any(e => 
                    e.From.Data == $"{r}-{c}" 
                    || e.To.Data == $"{r}-{c}");

                Console.ForegroundColor =
                    isPath ? ConsoleColor.White : map[r][c] ? ConsoleColor.Green : ConsoleColor.Red;

                Console.Write("\u25cf  ");

            }
            Console.WriteLine();
        }
        Console.ResetColor();




    }
}