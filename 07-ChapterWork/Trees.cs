namespace Chapter7;

public class TreeTesting
{
    public static void Demo()
    {
        TreeDemo();
    }

    public static void TreeDemo()
    {
        Tree<int> tree = new() { Root = new() { Data = 100 } };
        tree.Root.Children =
        [
            new() { Data = 50, Parent = tree.Root },
            new() { Data = 1, Parent = tree.Root },
            new() { Data = 150, Parent = tree.Root }
        ];
        tree.Root.Children[0].Children =
        [
            new() {Data = 12, Parent = tree.Root.Children[0]}
        ];
        tree.Root.Children[1].Children =
        [
            new() {Data = 70, Parent = tree.Root.Children[1]},
            new() {Data = 61, Parent = tree.Root.Children[1]}
        ];
        tree.Root.Children[2].Children =
        [
            new() {Data = 30, Parent = tree.Root.Children[2]},
            new() {Data = 5, Parent = tree.Root.Children[2]},
            new() {Data = 11, Parent = tree.Root.Children[2]}
        ];
        tree.Root.Children[2].Children[0].Children =
        [
            new() {Data = 96, Parent = tree.Root.Children[2].Children[0]},
            new() {Data = 9, Parent = tree.Root.Children[2].Children[0]}
        ];
        
    }

    public static void CompanyStructure()
    {
        Tree<Person> company = new()
        {
            Root = new()
            {
                Data = new Person("Marcin Jamro", "Chief Executive Officer"),
                Parent = null
            }
        };

        company.Root.Children =
        [
            new()
            {
                Data = new Person("John Smith", "Head of Development"),
                Parent = company.Root
            },
            new()
            {
                Data = new Person("Alice Batman", "Head of Research"),
                Parent = company.Root
            },
            new()
            {
                Data = new Person("Lily Smith", "Head of Sales"),
                Parent = company.Root
            }
        ];

        company.Root.Children[2].Children =
        [
            new()
            {
                Data = new Person("Anthony Black", "Senior Sales Specialist"),
                Parent = company.Root.Children[2]
            }
        ];
    }
}



public record Person(string Name, string Role);

public class TreeNode<T>
{
    public T? Data { get; set; }
    public TreeNode<T>? Parent { get; set; }
    public List<TreeNode<T>> Children { get; set; } = [];

    public int GetHeight()
    {
        var height = 1;
        var current = this;
        while (current.Parent != null)
        {
            height++;
            current = current.Parent;
        }

        return height;
    }
}

public class Tree<T>
{
    public TreeNode<T>? Root { get; set; }
}

