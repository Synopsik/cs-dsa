using System.Drawing;
using System.Drawing.Drawing2D;
namespace Chapter9;

public class FractalGeneration
{
    static List<Line> lines = [];
    
    public static void Demo()
    {
        const int maxSize = 1000;
        AddLine(14, 0, 0, 1000, (float)Math.PI * 1.5f);

        var xMin = lines.Min(l => Math.Min(l.X1, l.X2));
        var xMax = lines.Max(l => Math.Max(l.X1, l.X2));
        var yMin = lines.Min(l => Math.Min(l.Y1, l.Y2));
        var yMax = lines.Max(l => Math.Max(l.Y1, l.Y2));
        var size = Math.Max(xMax - xMin, yMax - yMin);
        var factor = maxSize / size;
        var width = (int)((xMax - xMin) * factor);
        var height = (int)((yMax - yMin) * factor);

        using Bitmap bitmap = new(width, height);
        using Graphics graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.White);
        graphics.SmoothingMode = SmoothingMode.AntiAlias;
        using Pen pen = new(Color.Black, 1);
        foreach (var line in lines)
        {
            pen.Width = line.GetLength() / 20;
            var sx = (line.X1 - xMin) * factor;
            var sy = (line.Y1 - yMin) * factor;
            var ex = (line.X2 - xMin) * factor;
            var ey = (line.Y2 - yMin) * factor;
            graphics.DrawLine(pen, sx, sy, ex, ey);
        }
        bitmap.Save($"{DateTime.Now:HH-mm-ss}.png");
        Console.WriteLine($"Saving to: {Directory.GetCurrentDirectory()}");
    }

    record Line(float X1, float Y1, float X2, float Y2)
    {
        public float GetLength() => 
            (float)Math.Sqrt(
                Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
    }
    
    static void AddLine(int level, float x, float y, float length, float angle)
    {
        if (level < 0) {return;}

        var endX = x + (float)(length * Math.Cos(angle));
        var endY = y + (float)(length * Math.Sin(angle));
        lines.Add(new(x, y, endX, endY));

        AddLine(level - 1, endX, endY, length * 0.8f, angle + (float)Math.PI * 0.3f);
        AddLine(level - 1, endX, endY, length * 0.6f, angle + (float)Math.PI * 1.7f);
    }
    
}