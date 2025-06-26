using Chapter5;

/*
/ ------------------------------------------------------------ /
/                     Tower of Hanoi example                   /
/ ------------------------------------------------------------ /
*/
Game game = new(5);
Visualization vis = new(game);
game.MoveCompleted += (s, e) => vis.Show((Game)s!);
await game.MoveAsync(game.DiscsCount, game.From, game.To, game.Auxiliary);
