namespace Chapter4;

public class ArtGallery
{
    public static void Demo()
    {
        var arts = GetArts();
        var images = new CircularlyLinkedList<string[]>();
        foreach (var art in arts) {images.AddLast(art);}

        var node = images.First!;
        var key = ConsoleKey.Spacebar;
        do
        {
            if (key == ConsoleKey.RightArrow)
            {
                node = node.Next()!;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                node = node.Prev()!;
            }

            Console.Clear();
            foreach (var line in node.Value)
            {
                Console.WriteLine(line);
            }
        } while ((key = Console.ReadKey().Key) != ConsoleKey.Escape);
    }
    
    
    
    
    
    
    private static string[][] GetArts() => [
        [
            "  +-----+  ",
            "o-| 1 o |-o",
            "  |  -  |  ",
            "  +-----+  ",
            "    | |    "
        ],
        [
            "o +-----+  ",
            " \\| o o |\\ ",
            "  |  o  | o",
            "  +-----+  ",
            "    / |    "
        ],
        [
            "  +-----+ o",
            " /| o 1 |/ ",
            "o |  -  |  ",
            "  +-----+  ",
            "    | \\    "
        ]
    ];
}