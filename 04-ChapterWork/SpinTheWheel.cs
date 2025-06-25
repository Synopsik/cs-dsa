namespace Chapter4;

public class SpinTheWheel
{
    public static async Task Demo()
    {
        var categories = new CircularlyLinkedList<string>();
        categories.AddLast("Sport");
        categories.AddLast("Culture");
        categories.AddLast("History");
        categories.AddLast("Geography");
        categories.AddLast("People");
        categories.AddLast("Technology");
        categories.AddLast("Nature");
        categories.AddLast("Science");

        await Spin(categories);
    }
    
    private static async Task Spin(CircularlyLinkedList<string> categories)
    {
        var isStopped = true;
        Random random = new();
        var targetTime = DateTime.Now;
        var ms = 0;

        foreach (string category in categories)
        {
            if (isStopped)
            {
                Console.WriteLine("Press [Enter] to start.");
                var key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    ms = random.Next(1000, 5000);
                    targetTime = DateTime.Now.AddMilliseconds(ms);
                    isStopped = false;
                    Console.WriteLine(category);
                }
                else {return;}
            }
            else
            {
                var remaining = (targetTime - DateTime.Now).TotalMilliseconds;
                // var waiting = Math.Max(100, (ms - remaining) / 5); Max doesn't protect from overflows
                // A wrapped-around negative value such as -4 000 is still _less_ than 100, so 100 would win
                var waiting = (int)Math.Clamp((ms - remaining)/5, 100, int.MaxValue);

                await Task.Delay(waiting);

                if (DateTime.Now >= targetTime)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    isStopped = true;
                }

                Console.WriteLine(category);
                Console.ResetColor();
            }
        }
    }
    
}