using System.Collections.Concurrent;
using Priority_Queue;

namespace Chapter5;

public class IncomingCall
{
    public int Id { get; set; }
    public int ClientID { get; set; }
    public DateTime CallTime { get; set; }
    public DateTime? AnswerTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Consultant { get; set; }
    public bool IsPriority { get; set; }
}

public class CallCenter
{
    private int _counter = 0;
    public SimplePriorityQueue<IncomingCall> Calls { get; private set; }
    public CallCenter() => Calls = new SimplePriorityQueue<IncomingCall>();

    public IncomingCall Call(int clientId, bool isPriority)
    {
        IncomingCall call = new()
        {
            Id = ++_counter,
            ClientID = clientId,
            CallTime = DateTime.Now,
            IsPriority = isPriority
        };
        Calls.Enqueue(call, isPriority ? 0 : 1);
        return call;
    }

    public IncomingCall? Answer(string consultant)
    {
        if (!AreWaitingCalls()) { return null; }

        var call = Calls.Dequeue();
        call.Consultant = consultant;
        call.AnswerTime = DateTime.Now;
        return call;
    }

    public void End(IncomingCall call) => call.EndTime = DateTime.Now;
    public bool AreWaitingCalls() => Calls.Count > 0;

}
