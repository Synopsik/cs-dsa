using System.Net.Http.Headers;

namespace Chapter9;

public class FibonacciSeries
{
    public long FibonacciBasic(int n)
    {
        if (n == 0) {return 0;}
        if (n == 1) {return 1;}

        return FibonacciBasic(n - 1) + FibonacciBasic(n - 2);
    }
    
    Dictionary<int, long> cache = [];
    
    public long FibonacciTopDown(int n)
    {
        if (n == 0) {return 0;}
        if (n == 1) {return 1;}
        if(cache.ContainsKey(n)) {return cache[n];}
       
        long result = FibonacciTopDown(n - 1) + FibonacciTopDown(n - 2);
        cache[n] = result;
        return result;
    }

    public long FibonacciBottomUp(int n)
    {
        if (n == 0) {return 0;}
        if (n == 1) {return 1;}

        long a = 0;
        long b = 1;
        for (var i = 2; i <= n; i++)
        {
            var result = a + b;
            a = b;
            b = result;
        }

        return b;
    }
    
    
}