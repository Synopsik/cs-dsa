namespace Chapter1;

public class Delegates
{
    public static void DelegatesDemo()
    {
        Mean arithmetic = (a, b, c) => (a + b + c) / 3;
        Mean geometric = delegate(double a, double b, double c)
        {
            return Math.Pow(a * b * c, 1 / 3.0);
        };
        Mean harmonic = Harmonic;

        double a = arithmetic.Invoke(5, 6.5, 7);
        double g = geometric.Invoke(5, 6.5, 7);
        double h = harmonic.Invoke(5, 6.5, 7);
        
        Console.WriteLine($"{a:F2} / {g:F2} / {h:F2}");

        double Harmonic(double a, double b, double c) =>
            3 / ((1 / a) + (1 / b) + (1 / c));
        
        
    }
}



delegate double Mean(double a, double b, double c);