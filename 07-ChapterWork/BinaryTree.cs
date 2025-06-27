namespace Chapter7;

public class BinaryTreeNode<T> : TreeNode<T>
{
    public new BinaryTreeNode<T>?[] Children { get; set; } = [null, null];

    public BinaryTreeNode<T>? Left
    {
        get { return Children[0]; }
        set { Children[0] = value; }
    }

    public BinaryTreeNode<T>? Right
    {
        get { return Children[1]; }
        set { Children[1] = value; }
    }
}
public class BinaryTree<T>
{
    public BinaryTreeNode<T>? Root { get; set; }
    public int Count { get; set; }

    private void TraversePreOrder(BinaryTreeNode<T>? node, List<BinaryTreeNode<T>> result)
    {
        if (node == null){return;}
        
        result.Add(node);
        TraversePreOrder(node.Left, result);
        TraversePreOrder(node.Right, result);
    }

    private void TraverseInOrder(BinaryTreeNode<T>? node, List<BinaryTreeNode<T>> result)
    {
        if (node == null){return;}
        
        TraverseInOrder(node.Left, result);
        result.Add(node);
        TraverseInOrder(node.Right, result);
    }

    private void TraversePostOrder(BinaryTreeNode<T>? node, List<BinaryTreeNode<T>> result)
    {
        if (node == null){return;}
        
        TraversePostOrder(node.Left, result);
        TraversePostOrder(node.Right, result);
        result.Add(node);
    }

    public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
    {
        List<BinaryTreeNode<T>> nodes = [];
        if (Root == null) {return nodes;}

        switch (mode)
        {
            case TraversalEnum.PreOrder: 
                TraversePreOrder(Root, nodes);
                break;
            case TraversalEnum.InOrder:
                TraverseInOrder(Root, nodes);
                break;
            case TraversalEnum.PostOrder:
                TraversePostOrder(Root, nodes);
                break;
        }

        return nodes;
    }
    
    public enum TraversalEnum {PreOrder, InOrder, PostOrder}
    
    public int GetHeight() => Root != null 
        ? Traverse(TraversalEnum.PreOrder).Max(n => n.GetHeight()) 
        : 0;
}

public class BinaryDemo
{
    public static void Demo()
    {
        BinaryTree<string> tree = GetTree();
        BinaryTreeNode<string>? node = tree.Root;
        while (node != null)
        {
            if (node.Left != null && node.Right != null)
            {
                Console.WriteLine(node.Data);
                node = Console.ReadKey(true).Key switch
                {
                    ConsoleKey.Y => node.Left,
                    ConsoleKey.N => node.Right,
                    _ => node
                };
            }
            else
            {
                Console.WriteLine(node.Data);
                node = null;
            }
        }
    }

    static BinaryTree<string> GetTree()
    {
        BinaryTree<string> tree = new();
        tree.Root = new BinaryTreeNode<string>()
        {
            Data = "Do you have an experience in app development?",
            Children =
            [
                new BinaryTreeNode<string>()
                {
                    Data = "Have you worked as a developer for 5+ years?",
                    Children =
                    [
                        new() { Data = "Apply as a senior developer" },
                        new() { Data = "Apply as a middle developer" }
                    ]
                },
                new BinaryTreeNode<string>()
                {
                    Data = "Have you completed university?",
                    Children =
                    [
                        new() { Data = "Apply as a junior developer" },
                        new BinaryTreeNode<string>()
                        {
                            Data = "WIll you find some time during the semester?",
                            Children =
                            [
                                new() { Data = "Apply for long-time internship" },
                                new() { Data = "Apply for summer internship" }
                            ]
                        }

                    ]
                },

            ]
        };
        tree.Count = 9;
        return tree;
    }
}