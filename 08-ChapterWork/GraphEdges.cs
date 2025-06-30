namespace Chapter8;

public class Demos
{
    public static void UndirectedUnweightedDemo()
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
        graph.AddEdge(n5, n6);
        graph.AddEdge(n5, n7);
        graph.AddEdge(n5, n8);
        graph.AddEdge(n6, n7);
        graph.AddEdge(n7, n8);
        
    }

    public static void DirectedWeightedDemo()
    {
        Graph<int> graph = new() { IsDirected = true, IsWeighted = true };

        var n1 = graph.AddNode(1);
        var n2 = graph.AddNode(2);
        var n3 = graph.AddNode(3);
        var n4 = graph.AddNode(4);
        var n5 = graph.AddNode(5);
        var n6 = graph.AddNode(6);
        var n7 = graph.AddNode(7);
        var n8 = graph.AddNode(8);

        graph.AddEdge(n1, n2, 9);
        graph.AddEdge(n1, n3, 5);
        graph.AddEdge(n2, n1, 3);
        graph.AddEdge(n2, n4, 18);
        graph.AddEdge(n3, n4, 12);
        graph.AddEdge(n4, n2, 2);
        graph.AddEdge(n4, n8, 8);
        graph.AddEdge(n5, n4, 9);
        graph.AddEdge(n5, n6, 2);
        graph.AddEdge(n5, n7, 5);
        graph.AddEdge(n5, n8, 3);
        graph.AddEdge(n6, n7, 1);
        graph.AddEdge(n7, n5, 4);
        graph.AddEdge(n7, n8, 6);
        graph.AddEdge(n8, n5, 3);
        

    }

    public static void DFSDemo()
    {
        Graph<int> graph = new() { IsDirected = true, IsWeighted = true };
        
        var n1 = graph.AddNode(1);
        var n2 = graph.AddNode(2);
        var n3 = graph.AddNode(3);
        var n4 = graph.AddNode(4);
        var n5 = graph.AddNode(5);
        var n6 = graph.AddNode(6);
        var n7 = graph.AddNode(7);
        var n8 = graph.AddNode(8);

        graph.AddEdge(n1, n2, 9);
        graph.AddEdge(n1, n3, 5);
        graph.AddEdge(n2, n1, 3);
        graph.AddEdge(n2, n4, 18);
        graph.AddEdge(n3, n4, 12);
        graph.AddEdge(n4, n2, 2);
        graph.AddEdge(n4, n8, 8);
        graph.AddEdge(n5, n4, 9);
        graph.AddEdge(n5, n6, 2);
        graph.AddEdge(n5, n7, 5);
        graph.AddEdge(n5, n8, 3);
        graph.AddEdge(n6, n7, 1);
        graph.AddEdge(n7, n5, 4);
        graph.AddEdge(n7, n8, 6);
        graph.AddEdge(n8, n5, 3);

        var nodes = graph.DFS();
        nodes.ForEach(Console.WriteLine);
    }

    public static void BFSDEMO()
    {
        Graph<int> graph = new() { IsDirected = true, IsWeighted = true };
        
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
        graph.AddEdge(n5, n6);
        graph.AddEdge(n5, n7);
        graph.AddEdge(n5, n8);
        graph.AddEdge(n6, n7);
        graph.AddEdge(n7, n8);

        var nodes = graph.BFS();
        nodes.ForEach(Console.WriteLine);
    }

    public static void MSTKruskal()
    {
        Graph<int> graph = new() { IsDirected = false, IsWeighted = true };

        var n1 = graph.AddNode(1);
        var n2 = graph.AddNode(2);
        var n3 = graph.AddNode(3);
        var n4 = graph.AddNode(4);
        var n5 = graph.AddNode(5);
        var n6 = graph.AddNode(6);
        var n7 = graph.AddNode(7);
        var n8 = graph.AddNode(8);

        graph.AddEdge(n1, n2, 3);
        graph.AddEdge(n1, n3, 5);
        graph.AddEdge(n2, n4, 4);
        graph.AddEdge(n3, n4, 12);
        graph.AddEdge(n4, n5, 9);
        graph.AddEdge(n4, n8, 8);
        graph.AddEdge(n5, n6, 4);
        graph.AddEdge(n5, n7, 5);
        graph.AddEdge(n5, n8, 1);
        graph.AddEdge(n6, n7, 6);
        graph.AddEdge(n7, n8, 20);

        var edges = graph.MSTKruskal();
        edges.ForEach(Console.WriteLine);
    }

    public static void MSTPrim()
    {
        Graph<int> graph = new() { IsDirected = false, IsWeighted = true };
        
        var n1 = graph.AddNode(1);
        var n2 = graph.AddNode(2);
        var n3 = graph.AddNode(3);
        var n4 = graph.AddNode(4);
        var n5 = graph.AddNode(5);
        var n6 = graph.AddNode(6);
        var n7 = graph.AddNode(7);
        var n8 = graph.AddNode(8);

        graph.AddEdge(n1, n2, 3);
        graph.AddEdge(n1, n3, 5);
        graph.AddEdge(n2, n4, 4);
        graph.AddEdge(n3, n4, 12);
        graph.AddEdge(n4, n5, 9);
        graph.AddEdge(n4, n8, 8);
        graph.AddEdge(n5, n6, 4);
        graph.AddEdge(n5, n7, 5);
        graph.AddEdge(n5, n8, 1);
        graph.AddEdge(n6, n7, 6);
        graph.AddEdge(n7, n8, 20);

        var edges = graph.MSTPrim();
        edges.ForEach(Console.WriteLine);
        
    }
}