namespace Chapter1;


// ------------------------------------------------------------------------------------------------ //
//                                             Structs                                              //
// ------------------------------------------------------------------------------------------------ //
// Struct for display the amount and currency type from the Currency Enum

public class Structs
{
    public static void StructsDemo()
    {
        Price priceRegular = new(500, CurrencyEnum.Usd);
        PriceShorter priceShorter = new(100, CurrencyEnum.Pln);
        Console.WriteLine(priceRegular);
        Console.WriteLine(priceShorter);

        // Using the with expression to create a copy of a structure
        // while modifying some properties and fields
        Price priceDiscount = priceRegular with { Amount = 50 };
        Console.WriteLine(priceDiscount);
    }
}

public readonly struct Price
{   
    // Constructor
    public Price(decimal amount, CurrencyEnum currency)
    {
        Amount = amount;
        Currency = currency;
    }
    // Readonly variables require either get only OR init to set variables
    public readonly decimal Amount { get; init; }
    public readonly CurrencyEnum Currency { get; init; }

    public override string ToString() => $"{Amount} {Currency}";
}

// The struct can be made shorter
public readonly struct PriceShorter(decimal amount, CurrencyEnum currency)
{
    // When using a primary constructor, these values are automatically assigned
    // so we don't need to explicitly initialize them again
    public readonly decimal Amount { get; init; } = amount;
    public readonly CurrencyEnum Currency { get; init; } = currency;
    public override string ToString() => $"{Amount} {Currency}";
}

public struct Measurement
{
    public DateTime Timestamp { get; }
    public float MeasValue { get; }
    
    public Measurement(DateTime timestamp, float measValue)
    {
        Timestamp = timestamp;
        MeasValue = measValue;
    }
    public override string ToString()
    {
        return $"{Timestamp:HH:mm:ss:fff}: {MeasValue:F3}";
    }
}