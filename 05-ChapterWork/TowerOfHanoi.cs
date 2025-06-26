namespace Chapter5;



public class Game
{
    public Stack<int> From { get; private set; }
    public Stack<int> To { get; private set; }
    public Stack<int> Auxiliary { get; private set; }
    public int DiscsCount { get; private set; }
    public int MovesCount { get; private set; }
    public event EventHandler<EventArgs>? MoveCompleted;

    public Game(int discsCount)
    {
        DiscsCount = discsCount;
        From = new Stack<int>();
        To = new Stack<int>();
        Auxiliary = new Stack<int>();
        for (var i = 0; i < discsCount; i++)
        {
            var size = discsCount - i;
            From.Push(size);
        }
    }

    public async Task MoveAsync(int discs, Stack<int> from, Stack<int> to, Stack<int> auxiliary)
    {
        if (discs == 0) {return;}

        await MoveAsync(discs - 1, from, auxiliary, to);
        to.Push(from.Pop());
        MovesCount++;
        MoveCompleted?.Invoke(this, EventArgs.Empty);
        await Task.Delay(250);
        await MoveAsync(discs - 1, auxiliary, to, from);
    }

    public static async Task Demo()
    {
        Game game = new(5);
        Visualization vis = new(game);
        game.MoveCompleted += (s, e) => vis.Show((Game)s!);
        await game.MoveAsync(game.DiscsCount, game.From, game.To, game.Auxiliary);
    }
}