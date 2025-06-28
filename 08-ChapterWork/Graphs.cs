namespace Chapter8;

public class Node<T>
{
    public int Index { get; set; }
    public required T Data { get; set; }
    public List<Node<T>> Neighbors { get; set; } = [];
    public List<int> Weights { get; set; } = [];
    public override string ToString() => $"Index: {Index}. Data: {Data}. Neighbors {Neighbors.Count}.";
}

public class Edge<T>
{
    public required Node<T> From { get; set; }
    public required Node<T> To { get; set; }
    public int Weight { get; set; }
    public override string ToString() => $"{From.Data} -> {To.Data}. Weight: {Weight}.";
}

public class Graph<T>
{
    public required bool IsDirected { get; set; }
    public required bool IsWeighted { get; set; }
    public List<Node<T>> Nodes { get; set; } = [];

    public Edge<T>? this[int from, int to]
    {
        get
        {
            var nodeFrom = Nodes[from];
            var nodeTo = Nodes[to];
            var i = nodeFrom.Neighbors.IndexOf(nodeTo);
            if (i < 0){return null;}

            Edge<T> edge = new()
            {
                From = nodeFrom,
                To = nodeTo,
                Weight = i < nodeFrom.Weights.Count ? nodeFrom.Weights[i] : 0
            };
            return edge;
        }
    }

    public Node<T> AddNode(T value)
    {
        Node<T> node = new() { Data = value };
        Nodes.Add(node);
        UpdateIndices();
        return node;
    }

    public void RemoveNode(Node<T> nodeToRemove)
    {
        Nodes.Remove(nodeToRemove);
        UpdateIndices();
        Nodes.ForEach(n => RemoveEdge(n, nodeToRemove));
    }

    public void AddEdge(Node<T> from, Node<T> to, int w = 0)
    {
        from.Neighbors.Add(to);
        if (IsWeighted) {from.Weights.Add(w);}

        if (!IsDirected)
        {
            to.Neighbors.Add(from);
            if (IsWeighted) {to.Weights.Add(w);}
        }
    }

    public void RemoveEdge(Node<T> from, Node<T> to)
    {
        var index = from.Neighbors.FindIndex(n => n == to);
        if (index < 0)  {return;}
        from.Neighbors.RemoveAt(index);
        if (IsWeighted){from.Weights.RemoveAt(index);}

        if (!IsDirected)
        {
            index = to.Neighbors.FindIndex(n => n == from);
            if (index < 0) {return;}

            to.Neighbors.RemoveAt(index);
            if (IsWeighted) {to.Weights.RemoveAt(index);}
        }
    }

    public List<Edge<T>> GetEdges()
    {
        List<Edge<T>> edges = [];
        foreach (var from in Nodes)
        {
            for (var i = 0; i < from.Neighbors.Count; i++)
            {
                var weight = i < from.Weights.Count ? from.Weights[i] : 0;
                Edge<T> edge = new()
                {
                    From = from,
                    To = from.Neighbors[i],
                    Weight = weight
                };
                edges.Add(edge);
            }
        }

        return edges;
    }

    private void UpdateIndices()
    {
        int i = 0;
        Nodes.ForEach(n => n.Index = i++);
    }
    
}

