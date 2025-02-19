using System;
using System.Collections.Generic;

class VotingSystem
{
    // Dictionary to store votes (Candidate Name -> Votes)
    private Dictionary<string, int> votesDictionary = new Dictionary<string, int>();

    // SortedDictionary to display results in alphabetical order of candidate names
    private SortedDictionary<string, int> sortedVotes = new SortedDictionary<string, int>();

    // LinkedHashMap to maintain the order of votes (using LinkedList to track order)
    private LinkedHashMap<string, int> linkedVotes = new LinkedHashMap<string, int>();

    // Add a vote for a candidate
    public void Vote(string candidateName)
    {
        // Increment the vote in the Dictionary
        if (votesDictionary.ContainsKey(candidateName))
        {
            votesDictionary[candidateName]++;
        }
        else
        {
            votesDictionary[candidateName] = 1;
        }

        // Increment the vote in the SortedDictionary
        sortedVotes[candidateName] = votesDictionary[candidateName];

        // Maintain order of votes in LinkedHashMap
        linkedVotes.Add(candidateName, votesDictionary[candidateName]);
    }

    // Display all votes in the Dictionary
    public void DisplayVotesDictionary()
    {
        Console.WriteLine("\nVotes in Dictionary (unsorted):");
        foreach (var vote in votesDictionary)
        {
            Console.WriteLine($"{vote.Key}: {vote.Value} votes");
        }
    }

    // Display all votes in the SortedDictionary (sorted by candidate name)
    public void DisplaySortedVotes()
    {
        Console.WriteLine("\nVotes in SortedDictionary (sorted by candidate name):");
        foreach (var vote in sortedVotes)
        {
            Console.WriteLine($"{vote.Key}: {vote.Value} votes");
        }
    }

    // Display all votes in the LinkedHashMap (maintains order of voting)
    public void DisplayLinkedVotes()
    {
        Console.WriteLine("\nVotes in LinkedHashMap (maintains order of voting):");
        foreach (var vote in linkedVotes)
        {
            Console.WriteLine($"{vote.Key}: {vote.Value} votes");
        }
    }
}

// Custom LinkedHashMap class to maintain insertion order
public class LinkedHashMap<K, V> : Dictionary<K, V>
{
    private LinkedList<K> order = new LinkedList<K>();

    public new void Add(K key, V value)
    {
        if (!ContainsKey(key))
        {
            order.AddLast(key);
        }
        base[key] = value;
    }

    public new void Clear()
    {
        base.Clear();
        order.Clear();
    }

    public IEnumerable<KeyValuePair<K, V>> GetOrderedItems()
    {
        foreach (var key in order)
        {
            yield return new KeyValuePair<K, V>(key, this[key]);
        }
    }
}

class Program
{
    static void Main()
    {
        VotingSystem votingSystem = new VotingSystem();

        // Voting for candidates
        votingSystem.Vote("Alice");
        votingSystem.Vote("Bob");
        votingSystem.Vote("Alice");
        votingSystem.Vote("Charlie");
        votingSystem.Vote("Bob");
        votingSystem.Vote("Alice");

        // Displaying the results
        votingSystem.DisplayVotesDictionary();
        votingSystem.DisplaySortedVotes();
        votingSystem.DisplayLinkedVotes();
    }
}
