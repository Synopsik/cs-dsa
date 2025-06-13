namespace Chapter1;

// ------------------------------------------------------------------------------------------------ //
//                                              Enums                                               //
// ------------------------------------------------------------------------------------------------ //
public enum CurrencyEnum { Pln, Usd, Eur }

[Flags]
enum ActionEnum
/*
    Bit values can be combined to create various permission combinations
    Using binary notation, we have a unique set of values ranging from
    0b_0000_0000 - 0b_0011_1111
*/
{
    None    = 0b_0000_0000,
    List    = 0b_0000_0001, // 1
    Details = 0b_0000_0010, // 2
    Add     = 0b_0000_0100, // 4
    Edit    = 0b_0000_1000, // 8
    Delete  = 0b_0001_0000, // 16
    Publish = 0b_0010_0000  // 32
}
