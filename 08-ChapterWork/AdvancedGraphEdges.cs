namespace Chapter8;

public class AdvancedGraphEdges
{
    public static void TeleComDemo()
    {
        Graph<string> graph = new() { IsDirected = false, IsWeighted = true };

        Node<string> nodeB1 = graph.AddNode("B1");
        Node<string> nodeB2 = graph.AddNode("B2");
        Node<string> nodeB3 = graph.AddNode("B3");
        Node<string> nodeB4 = graph.AddNode("B4");
        Node<string> nodeB5 = graph.AddNode("B5");
        Node<string> nodeB6 = graph.AddNode("B6");
        Node<string> nodeR1 = graph.AddNode("R1");
        Node<string> nodeR2 = graph.AddNode("R2");
        Node<string> nodeR3 = graph.AddNode("R3");
        Node<string> nodeR4 = graph.AddNode("R4");
        Node<string> nodeR5 = graph.AddNode("R5");
        Node<string> nodeR6 = graph.AddNode("R6");

        graph.AddEdge(nodeB1, nodeB2, 2);
        graph.AddEdge(nodeB1, nodeB3, 20);
        graph.AddEdge(nodeB1, nodeB4, 30);
        graph.AddEdge(nodeB2, nodeB3, 30);
        graph.AddEdge(nodeB2, nodeB4, 20);
        graph.AddEdge(nodeB2, nodeR2, 25);
        graph.AddEdge(nodeB3, nodeB4, 2);
        graph.AddEdge(nodeB4, nodeR4, 25);
        graph.AddEdge(nodeR1, nodeR2, 1);
        graph.AddEdge(nodeR2, nodeR3, 1);
        graph.AddEdge(nodeR3, nodeR4, 1);
        graph.AddEdge(nodeR1, nodeR5, 75);
        graph.AddEdge(nodeR3, nodeR6, 100);
        graph.AddEdge(nodeR5, nodeR6, 3);
        graph.AddEdge(nodeR6, nodeB5, 3);
        graph.AddEdge(nodeR6, nodeB6, 10);
        graph.AddEdge(nodeB5, nodeB6, 6);
        
        
        Console.WriteLine("Minimum Spanning Tree - Kruskal:");
        var kruskal = graph.MSTKruskal();
        kruskal.ForEach(Console.WriteLine);
        Console.WriteLine("Cost: " + kruskal.Sum(e => e.Weight));
        
        Console.WriteLine("\nMinimum Spanning Tree - Prim:");
        var prim = graph.MSTPrim();
        prim.ForEach(Console.WriteLine);
        Console.WriteLine("Cost: " + prim.Sum(e => e.Weight));

    }

    public static void ColorDemo()
    {
        Graph<int> graph = new() { IsDirected = false, IsWeighted = false };

        var n1 = graph.AddNode(1);
        var n2 = graph.AddNode(2);
        var n3 = graph.AddNode(3);
        var n4 = graph.AddNode(4);
        var n5 = graph.AddNode(5);
        var n6 = graph.AddNode(6);
        var n7 = graph.AddNode(7);
        var n8 = graph.AddNode(8);

        graph.AddEdge(n1, n2);
        graph.AddEdge(n1, n3);
        graph.AddEdge(n2, n4);
        graph.AddEdge(n3, n4);
        graph.AddEdge(n4, n5);
        graph.AddEdge(n4, n8);
        graph.AddEdge(n5, n6);
        graph.AddEdge(n5, n7);
        graph.AddEdge(n5, n8);
        graph.AddEdge(n6, n7);
        graph.AddEdge(n7, n8);

        var colors = graph.Color();
        for (var i = 0; i < colors.Length; i++)
        {
            Console.WriteLine($"Node {graph.Nodes[i].Data}: {colors[i]}");
        }
    }

    public static void VoivodeshipDemo()
    {
        Graph<string> graph = new() { IsDirected = false, IsWeighted = false };

        List<string> borders =
        [
            "PK:LU|SK|MA",
            "LU:PK|SK|MZ|PD",
            "SK:PK|MA|SL|LD|MZ|LU",
            "MA:PK|SK|SL",
            "SL:MA|SK|LD|OP",
            "LD:SL|SK|MZ|KP|WP|OP",
            "WP:LD|KP|PM|ZP|LB|DS|OP",
            "OP:SL|LD|WP|DS",
            "MZ:LU|SK|LD|KP|WM|PD",
            "PD:LU|MZ|WM",
            "WM:PD|MZ|KP|PM",
            "KP:MZ|LD|WP|PM|WM",
            "PM:WM|KP|WP|ZP",
            "ZP:PM|WP|LB",
            "LB:ZP|WP|DS",
            "DS:LB|WP|OP"
        ];

        Dictionary<string, Node<string>> nodes = [];
        foreach (var border in borders)
        {
            var parts = border.Split(':');
            var name = parts[0];
            nodes[name] = graph.AddNode(name);
        }

        foreach (var border in borders)
        {
            var parts = border.Split(':');
            var name = parts[0];
            var vicinities = parts[1].Split('|');
            foreach (var vicinity in vicinities)
            {
                var from = nodes[name];
                var to = nodes[vicinity];
                if (!from.Neighbors.Contains(to))
                {
                    graph.AddEdge(from, to);
                }
            }
        }

        var colors = graph.Color();
        for (var i = 0; i < colors.Length; i++)
        {
            Console.WriteLine($"{graph.Nodes[i].Data}: {colors[i]}");
        }
    }
}