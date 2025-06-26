using System.Collections.Generic;
namespace Chapter5;

public class Stack
{
    public static void Demo()
    {
        var text = "SYNOPSIK";
        
        // Create stack chars
        var chars = new Stack<char>();
        
        // Push each char from string var text
        foreach (var c in text) {chars.Push(c);}
        
        // Pop each char from the stack and print to the console
        while (chars.Count > 0) {Console.Write(chars.Pop());}
    }
}