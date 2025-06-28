using System.Text.RegularExpressions;
namespace Chapter7;

public static class TrieDemo
{
    public static void Demo1()
    {
        Trie trie = new();
        trie.Insert("algorithm");
        trie.Insert("aid");
        trie.Insert("aim");
        trie.Insert("air");
        trie.Insert("ai");
        trie.Insert("airport");
        trie.Insert("airplane");
        trie.Insert("allergy");
        trie.Insert("allowance");
        trie.Insert("all");
        trie.Insert("allow");

        var isAir = trie.DoesExist("air");
        var words = trie.SearchByPrefix("al");
        foreach (var word in words)
        {
            Console.WriteLine(word);
        }
    }
    
    public static async Task Demo2()
    {
        Trie trie = new();
        var countries = await File.ReadAllLinesAsync("C:\\Users\\steve\\Documents\\Projects\\Rider\\07-ChapterWork\\Countries.txt");
        foreach (var country in countries)
        {
            Regex regex = new("[^a-z]");
            var name = country.ToLower();
            name = regex.Replace(name, string.Empty);
            trie.Insert(name);
        }
        
        
        var text = string.Empty;
        while (true)
        {
            Console.Write("Enter next character: ");
            var key = Console.ReadKey();
            if (key.KeyChar < 'a' || key.KeyChar > 'z') {return;}

            text = (text + key.KeyChar).ToLower();
            var results = trie.SearchByPrefix(text);
            if (results.Count == 0) {return;}
            Console.WriteLine($"\nSuggestions for {text.ToUpper()}:");
            results.ForEach(r => Console.WriteLine(r.ToUpper()));
            Console.WriteLine();
        }
    }
}


public class TrieNode
{
    public TrieNode[] Children { get; set; } = new TrieNode[26];
    public bool IsWord { get; set; } = false;
}

public class Trie
{
    private readonly TrieNode _root = new();

    public bool DoesExist(string word)
    {
        var current = _root;
        foreach (var c in word)
        {
            var child = current.Children[c - 'a'];
            if (child == null){return false;}
            current = child;
        }
        return current.IsWord;
    }

    public void Insert(string word)
    {
        var current = _root;
        foreach (var c in word)
        {
            var i = c - 'a';
            current.Children[i] = current.Children[i] ?? new();
            current = current.Children[i];
        }

        current.IsWord = true;
    }

    public List<string> SearchByPrefix(string prefix)
    {
        var current = _root;
        foreach (var c in prefix)
        {
            var child = current.Children[c - 'a'];
            if(child == null){return [];}
            current = child;
        }

        List<string> results = [];
        GetAllWithPrefix(current, prefix, results);
        return results;
    }

    private void GetAllWithPrefix(TrieNode node, string prefix, List<string> results)
    {
        if (node == null) {return;}
        if (node.IsWord) {results.Add(prefix);}

        for (var c = 'a'; c <= 'z'; c++)
        {
            GetAllWithPrefix(node.Children[c - 'a'], prefix + c, results);
        }
    }
    
}

