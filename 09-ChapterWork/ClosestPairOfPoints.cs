namespace Chapter9;

public record Point(int X, int Y)
{
    public float GetDistanceTo(Point p) => 
        (float)
        Math.Sqrt(
            Math.Pow(X - p.X, 2) + Math.Pow(Y - p.Y, 2));
}

public record Result(Point P1, Point P2, double Distance);


public class ClosestPairOfPoints
{
    public static void Demo()
    {
        List<Point> points =
        [
            new Point(6, 45),
            new Point(12, 8),
            new Point(14, 31),
            new Point(24, 18),
            new Point(32, 26),
            new Point(40, 41),
            new Point(44, 6),
            new Point(57, 20),
            new Point(60, 35),
            new Point(72, 9),
            new Point(73, 41),
            new Point(85, 25),
            new Point(92, 8),
            new Point(93, 43)
        ];

        // Sort all points by X Coord
        points.Sort((a, b) => a.X.CompareTo(b.X));
        
        // Search through the list of points to find the closest pair
        var closestPair = FindClosestPair(points.ToArray());
        
        if (closestPair != null) // Print results if found
        {
            Console.WriteLine("Closest pair: ({0}, {1}) and ({2}, {3}) with distance: {4:F2}", 
                closestPair.P1.X,
                closestPair.P1.Y,
                closestPair.P2.X,
                closestPair.P2.Y,
                closestPair.Distance);
        }



    }

    static Result? FindClosestPair(Point[] points)
    {
        if (points.Length <= 1) {return null;}
        if (points.Length <= 3) {return Closest(points);}

        var m = points.Length / 2;
        var r = Closer(
            FindClosestPair(points.Take(m).ToArray())!,
            FindClosestPair(points.Skip(m).ToArray())!);

        var strip = points.Where(p => Math.Abs(p.X - points[m].X) < r.Distance).ToArray();
        return Closer(r, Closest(strip));
    }

    static Result Closest(Point[] points)
    {
        Result result = new(points[0], points[0], double.MaxValue);
        for (var i = 0; i < points.Length; i++)
        {
            for (var j = i + 1; j < points.Length; j++)
            {
                var distance = points[i].GetDistanceTo(points[j]);
                if (distance < result.Distance)
                {
                    result = new(points[i], points[j], distance);
                }
            }
        }
        return result;
    }

    static Result Closer(Result r1, Result r2) => r1.Distance < r2.Distance ? r1 : r2;

}