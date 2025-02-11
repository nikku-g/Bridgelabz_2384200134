using System;
using System.Collections.Generic;

public class User
{
    public int UserID { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<int> FriendIDs { get; set; }

    public User(int userID, string name, int age)
    {
        UserID = userID;
        Name = name;
        Age = age;
        FriendIDs = new List<int>();
    }
}

public class SocialMediaLinkedList
{
    public class Node
    {
        public User Data;
        public Node Next;

        public Node(User data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;

    public SocialMediaLinkedList()
    {
        head = null;
    }

    // Add a new user to the list
    public void AddUser(int userID, string name, int age)
    {
        User user = new User(userID, name, age);
        Node newNode = new Node(user);

        if (head == null)
        {
            head = newNode;
        }
        else
        {
            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
        }
    }

    // Search for a user by Name
    public User SearchByName(string name)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                return temp.Data;
            }
            temp = temp.Next;
        }
        return null; // User not found
    }

    // Search for a user by UserID
    public User SearchByUserID(int userID)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.UserID == userID)
            {
                return temp.Data;
            }
            temp = temp.Next;
        }
        return null; // User not found
    }

    // Add a friend connection between two users
    public void AddFriendConnection(int userID1, int userID2)
    {
        User user1 = SearchByUserID(userID1);
        User user2 = SearchByUserID(userID2);

        if (user1 != null && user2 != null)
        {
            if (!user1.FriendIDs.Contains(userID2))
            {
                user1.FriendIDs.Add(userID2);
            }

            if (!user2.FriendIDs.Contains(userID1))
            {
                user2.FriendIDs.Add(userID1);
            }

            Console.WriteLine($"User {user1.Name} and User {user2.Name} are now friends.");
        }
        else
        {
            Console.WriteLine("One or both users not found.");
        }
    }

    // Remove a friend connection between two users
    public void RemoveFriendConnection(int userID1, int userID2)
    {
        User user1 = SearchByUserID(userID1);
        User user2 = SearchByUserID(userID2);

        if (user1 != null && user2 != null)
        {
            if (user1.FriendIDs.Contains(userID2))
            {
                user1.FriendIDs.Remove(userID2);
                Console.WriteLine($"User {user1.Name} removed {user2.Name} from their friends list.");
            }

            if (user2.FriendIDs.Contains(userID1))
            {
                user2.FriendIDs.Remove(userID1);
                Console.WriteLine($"User {user2.Name} removed {user1.Name} from their friends list.");
            }
        }
        else
        {
            Console.WriteLine("One or both users not found.");
        }
    }

    // Find mutual friends between two users
    public void FindMutualFriends(int userID1, int userID2)
    {
        User user1 = SearchByUserID(userID1);
        User user2 = SearchByUserID(userID2);

        if (user1 != null && user2 != null)
        {
            List<int> mutualFriends = new List<int>();
            foreach (var friendID in user1.FriendIDs)
            {
                if (user2.FriendIDs.Contains(friendID))
                {
                    mutualFriends.Add(friendID);
                }
            }

            if (mutualFriends.Count > 0)
            {
                Console.WriteLine("Mutual friends:");
                foreach (var friendID in mutualFriends)
                {
                    User friend = SearchByUserID(friendID);
                    Console.WriteLine(friend.Name);
                }
            }
            else
            {
                Console.WriteLine("No mutual friends found.");
            }
        }
        else
        {
            Console.WriteLine("One or both users not found.");
        }
    }

    // Display all friends of a specific user
    public void DisplayFriends(int userID)
    {
        User user = SearchByUserID(userID);
        if (user != null)
        {
            Console.WriteLine($"{user.Name}'s friends:");
            if (user.FriendIDs.Count == 0)
            {
                Console.WriteLine("No friends.");
            }
            else
            {
                foreach (var friendID in user.FriendIDs)
                {
                    User friend = SearchByUserID(friendID);
                    Console.WriteLine(friend.Name);
                }
            }
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    // Count the number of friends for a user
    public void CountFriends(int userID)
    {
        User user = SearchByUserID(userID);
        if (user != null)
        {
            Console.WriteLine($"{user.Name} has {user.FriendIDs.Count} friends.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

    // Display all users in the list
    public void DisplayAllUsers()
    {
        Node temp = head;
        Console.WriteLine("All Users:");
        while (temp != null)
        {
            Console.WriteLine($"User ID: {temp.Data.UserID}, Name: {temp.Data.Name}, Age: {temp.Data.Age}");
            temp = temp.Next;
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SocialMediaLinkedList socialMedia = new SocialMediaLinkedList();

        // Add users
        socialMedia.AddUser(1, "Alice", 25);
        socialMedia.AddUser(2, "Bob", 30);
        socialMedia.AddUser(3, "Charlie", 22);
        socialMedia.AddUser(4, "Diana", 28);

        // Add friend connections
        socialMedia.AddFriendConnection(1, 2);
        socialMedia.AddFriendConnection(1, 3);
        socialMedia.AddFriendConnection(2, 4);

        // Display all users
        socialMedia.DisplayAllUsers();

        // Display friends of a user
        socialMedia.DisplayFriends(1); // Alice's friends

        // Find mutual friends between two users
        socialMedia.FindMutualFriends(1, 2); // Alice and Bob

        // Count friends of a user
        socialMedia.CountFriends(2); // Bob's friends count

        // Remove a friend connection
        socialMedia.RemoveFriendConnection(1, 3); // Alice and Charlie
        socialMedia.DisplayFriends(1); // Alice's friends after removal

        // Search for a user by name
        User user = socialMedia.SearchByName("Diana");
        if (user != null)
        {
            Console.WriteLine($"Found user: {user.Name}, Age: {user.Age}");
        }
    }
}
