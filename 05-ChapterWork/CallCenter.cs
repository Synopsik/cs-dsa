namespace Chapter5;

public class IncomingCall
{
    public int Id { get; set; }
    public int ClientID { get; set; }
    public DateTime CallTime { get; set; }
    public DateTime? AnswerTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Consultant { get; set; }
}

public class CallCenter
{
    private int _counter = 0;
    public Queue<IncomingCall> Calls { get; private set; }
    public CallCenter() => Calls = new Queue<IncomingCall>();

    public IncomingCall Call(int clientId)
    {
        IncomingCall call = new()
        {
            Id = ++_counter,
            ClientID = clientId,
            CallTime = DateTime.Now
        };
        Calls.Enqueue(call);
        return call;
    }

    public IncomingCall? Answer(string consultant)
    {
        if (!AreWaitingCalls()) {return null;}

        IncomingCall call = Calls.Dequeue();
        call.Consultant = consultant;
        call.AnswerTime = DateTime.Now;
        return call;
    }

    public void End(IncomingCall call) => call.EndTime = DateTime.Now;
    public bool AreWaitingCalls() => Calls.Count > 0;

    
}


