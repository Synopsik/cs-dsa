using System;
using System.Diagnostics;

public sealed class MyTimer : IDisposable
{
    private readonly Stopwatch _sw = Stopwatch.StartNew();

    public void Restart() => _sw.Restart();

    public TimeSpan Elapsed => _sw.Elapsed;

    public override string ToString() => $"{_sw.Elapsed.TotalMilliseconds:F3} ms";

    public void Dispose() => _sw.Stop();
}