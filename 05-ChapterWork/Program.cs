using Chapter5;

/*
/ ------------------------------------------------------------ /
/                     Tower of Hanoi example                   /
/ ------------------------------------------------------------ /
/
Game game = new(5);
Visualization vis = new(game);
game.MoveCompleted += (s, e) => vis.Show((Game)s!);
await game.MoveAsync(game.DiscsCount, game.From, game.To, game.Auxiliary);
*/



Random random = new();

CallCenter center = new();
center.Call(1234);
center.Call(5678);
center.Call(1468);
center.Call(9641);

void Log(string text) => Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {text}");

while (center.AreWaitingCalls())
{
    IncomingCall call = center.Answer("Marcin")!;
    
    Log($"Call #{call.Id} from client " +
            $"#{call.ClientID} answered by {call.Consultant}.");
    
    await Task.Delay(random.Next(1000, 10000));
    
    center.End(call);
    
    Log($"Call #{call.Id} from client " +
            $"#{call.ClientID} ended by {call.Consultant}");
}

