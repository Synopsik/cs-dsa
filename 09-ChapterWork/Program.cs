using Chapter9;

// --------------------------------------------------------------- //
//                       Fibonacci Series Demo                     //
// --------------------------------------------------------------- //
const int num = 30;

var timer = new MyTimer();

timer.Restart();
var largeFib = new FibonacciSeries().FibonacciBottomUp(5000);
Console.WriteLine($"5000: " + largeFib + $"\nTime: {timer}\n");

for (var i = 20; i <= num; i += 10)
{
    timer.Restart();
    var FibonacciB = new FibonacciSeries().FibonacciBasic(i);
    Console.WriteLine($"{i}: " + FibonacciB + $"\nTime: {timer}");

    timer.Restart();
    var FibonacciTD = new FibonacciSeries().FibonacciTopDown(i);
    Console.WriteLine($"{i}: " + FibonacciTD + $"\nTime: {timer}");

    timer.Restart();
    var FibonacciBU = new FibonacciSeries().FibonacciBottomUp(i);
    Console.WriteLine($"{i}: " + FibonacciBU + $"\nTime: {timer}" + "\n");
}



// --------------------------------------------------------------- //
//                         Maximum Coin Change                     //
// --------------------------------------------------------------- //
int[] coinDenominations = [1, 5, 10, 25, 100];
var coins = GetCoins(158);
coins.ForEach(Console.WriteLine);

List<int> GetCoins(int amount)
{
    List<int> selectedCoins = []; // Create an empty list for selected coins
    
    // Begin looping from the largest denomination to the smallest
    for (var i = coinDenominations.Length - 1; i >= 0; i--)
    {
        // While our current amount is larger than the indexed denomination in the for loop (158 > 100)
        // Use the currently indexed denomination until amount var is smaller
        while (amount >= coinDenominations[i])
        {
            // Reduce the total amount by the largest available denomination (158-100=58)
            amount -= coinDenominations[i];
            // Add the used coin to the selectedCoin array
            selectedCoins.Add(coinDenominations[i]);
        }
    }
    return selectedCoins; // Return the created from used coins
}