namespace Chapter5;

public class Visualization
{
    
    public Visualization(Game game)
    {
        _game = game;
        _columnSize = Math.Max(6, GetDiscWidth(_game.DiscsCount) + 2);
        _board = new char[_game.DiscsCount, _columnSize * 3];
    }

    public void Show(Game game)
    {
        Console.Clear();
        if (game.DiscsCount <= 0) {return;}

        FillEmptyBoard();
        FillRodOnBoard(1, game.From);
        FillRodOnBoard(2, game.To);
        FillRodOnBoard(3, game.Auxiliary);
        
        Console.WriteLine(Center("FROM") + Center("TO") + Center("AUXILIARY"));

        DrawBoard();
        Console.WriteLine($"\nMoves: {game.MovesCount}");
        Console.WriteLine($"Discs: {game.DiscsCount}");
    }
    
    
    
    
    
    private readonly Game _game;
    private readonly int _columnSize;
    private readonly char[,] _board;

    private static int GetDiscWidth(int size) => (2 * size) - 1;

    private void FillEmptyBoard()
    {
        for (var y = 0; y < _board.GetLength(0); y++)
        {
            for (var x = 0; x < _board.GetLength(1); x++)
            {
                _board[y, x] = ' ';
            }
        }
    }

    private void FillRodOnBoard(int column, Stack<int> stack)
    {
        var discsCount = _game.DiscsCount;
        var margin = _columnSize * (column - 1);

        for (var y = 0; y < stack.Count; y++)
        {
            var size = stack.ElementAt(y);
            var row = discsCount - (stack.Count - y);
            var columnStart = margin + discsCount - size;
            var columnEnd = columnStart + GetDiscWidth(size);
            for (var x = columnStart; x <= columnEnd; x++)
            {
                _board[row, x] = '=';
            }
        }
    }
    
    
    
    
}
