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


    public List<Node<T>> DFS()
    {
        var isVisited = new bool[Nodes.Count];
        List<Node<T>> result = [];
        DFS(isVisited, Nodes[0], result);
        return result;
    }

    private void DFS(bool[] isVisited, Node<T> node, List<Node<T>> result)
    {
        result.Add(node);
        isVisited[node.Index] = true;

        foreach (var neighbor in node.Neighbors)
        {
            if (!isVisited[neighbor.Index])
            {
                DFS(isVisited, neighbor, result);
            }
        }
    }

    public List<Node<T>> BFS() => BFS(Nodes[0]);

    private List<Node<T>> BFS(Node<T> node)
    {
        var isVisited = new bool[Nodes.Count];
        isVisited[node.Index] = true;

        List<Node<T>> result = [];
        Queue<Node<T>> queue = [];
        queue.Enqueue(node);
        while (queue.Count > 0)
        {
            var next = queue.Dequeue();
            result.Add(next);

            foreach (var neighbor in next.Neighbors)
            {
                if (!isVisited[neighbor.Index])
                {
                    isVisited[neighbor.Index] = true;
                    queue.Enqueue(neighbor);
                }
            }
        }
        return result;
    }

    public List<Edge<T>> MSTKruskal()
    {
        var edges = GetEdges();
        edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        Queue<Edge<T>> queue = new(edges);

        Subset<T>[] subsets = new Subset<T>[Nodes.Count];
        for (var i = 0; i < Nodes.Count; i++)
        {
            subsets[i] = new() { Parent = Nodes[i] };
        }

        List<Edge<T>> result = [];
        while (result.Count < Nodes.Count - 1)
        {
            var edge = queue.Dequeue();
            var from = GetRoot(subsets, edge.From);
            var to = GetRoot(subsets, edge.To);
            if (from == to){continue;}

            result.Add(edge);
            Union(subsets, from, to);
        }
        return result;
    }

    private Node<T> GetRoot(Subset<T>[] ss, Node<T> node)
    {
        var i = node.Index;
        ss[i].Parent = ss[i].Parent != node ? GetRoot(ss, ss[i].Parent) : ss[i].Parent;
        return ss[i].Parent;
    }

    private void Union(Subset<T>[] ss, Node<T> a, Node<T> b)
    {
        ss[b.Index].Parent = ss[a.Index].Rank >= ss[b.Index].Rank ? a : ss[b.Index].Parent;
        ss[a.Index].Parent = ss[a.Index].Rank < ss[b.Index].Rank ? b : ss[a.Index].Parent;

        if (ss[a.Index].Rank == ss[b.Index].Rank)
        {
            ss[a.Index].Rank++;
        }
    }

    public class Subset<T>
    {
        public required Node<T> Parent { get; set; }
        public int Rank { get; set; }
        public override string ToString() => $"Rank: {Rank}. Parent: {Parent.Data}. Index: {Parent.Index}";
    }

    public List<Edge<T>> MSTPrim()
    {
        var previous = new int[Nodes.Count];
        previous[0] = -1;

        var minWeight = new int[Nodes.Count];
        Array.Fill(minWeight, int.MaxValue);
        minWeight[0] = 0;

        var isInMST = new bool[Nodes.Count];
        Array.Fill(isInMST, false);

        for (var i = 0; i < Nodes.Count - 1; i++)
        {
            var mwi = GetMinWeightIndex(minWeight, isInMST);
            isInMST[mwi] = true;

            for (var j = 0; j < Nodes.Count; j++)
            {
                var edge = this[mwi, j];
                var weight = edge != null ? edge.Weight : -1;
                if (edge != null && !isInMST[j] && weight < minWeight[j])
                {
                    previous[j] = mwi;
                    minWeight[j] = weight;
                }
            }
        }
        List<Edge<T>> result = [];
        for (var i = 1; i < Nodes.Count; i++)
        {
            result.Add(this[previous[i], i]!);
        }
        return result;
    }

    private int GetMinWeightIndex(int[] weights, bool[] isInMST)
    {
        var minValue = int.MaxValue;
        var minIndex = 0;

        for (var i = 0; i < Nodes.Count; i++)
        {
            if (!isInMST[i] && weights[i] < minValue)
            {
                minValue = weights[i];
                minIndex = i; 
            }
        }

        return minIndex;
    }
}

