using System.Diagnostics;
using System.Text;
namespace Chapter9;

public class PasswordGuess
{
    private const string secretPassword = "csharp";
    private int charsCount = 0;
    private char[] chars = new char[36];

    public void Demo()
    {
        for (var c = 'a'; c <= 'z'; c++)
        {
            chars[charsCount++] = c;
        }

        for (var c = '0'; c <= '9'; c++)
        {
            chars[charsCount++] = c;
        }

        for (var length = 2; length <= 8; length++)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var indices = new int[length];
            for (var i = 0; i < length; i++) {indices[i] = 0;}

            var isCompleted = false;
            StringBuilder builder = new();
            long count = 0;
            while (!isCompleted)
            {
                builder.Clear();
                for (var i = 0; i < length; i++)
                {
                    builder.Append(chars[indices[i]]);
                }

                var guess = builder.ToString();
                if (guess == secretPassword)
                {
                    Console.WriteLine("Found.");
                }

                count++;

                if (count % 10000000 == 0)
                {
                    Console.WriteLine($" > Checked: {count}.");
                }

                indices[length - 1]++;
                
                if (indices[length - 1] >= charsCount)
                {
                    for (var i = length - 1; i >= 0; i--)
                    {
                        indices[i] = 0;
                        indices[i - 1]++;
                        if (indices[i-1] < charsCount)  {break;}

                        if (i - 1 == 0 && indices[0] >= charsCount)
                        {
                            isCompleted = true;
                            break;
                        }
                    }
                } 
            }

            sw.Stop();
            var seconds = (int)sw.ElapsedMilliseconds / 1000;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{length} chars: {seconds}s");
            Console.ResetColor();
        }



    }
}