namespace Chapter3;
using System.Globalization;

public class MonthNames
{
    public static void Demo()
    {
        CultureInfo culture = new("en");
        string[] months = new string[12];

        for (int month = 1; month <= 12; month++)
        {
            DateTime firstDay = new(DateTime.Now.Year, month, 1);
            string name = firstDay.ToString("MMMM-yy", culture);
            months[month - 1] = name;
        }

        foreach (string m in months)
        {
            Console.WriteLine(m);
        }
    }
}