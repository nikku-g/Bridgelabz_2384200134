using System;
using System.Collections.Generic;

public class Movie
{
    public string Title { get; set; }
    public string Director { get; set; }
    public int YearOfRelease { get; set; }
    public double Rating { get; set; }

    public Movie(string title, string director, int yearOfRelease, double rating)
    {
        Title = title;
        Director = director;
        YearOfRelease = yearOfRelease;
        Rating = rating;
    }
}


public class Node
{
    public Movie Data;
    public Node Next;
    public Node Prev;

    public Node(Movie data)
    {
        Data = data;
        Next = null;
        Prev = null;
    }
}


public class MovieList
{
    private Node head;
    private Node tail;

    public MovieList()
    {
        head = null;
        tail = null;
    }

    // Add a movie at the beginning
    public void AddAtBeginning(Movie movie)
    {
        Node n = new Node(movie);
        if (head == null)
        {
            head = tail = n;
        }
        else
        {
            n.Next = head;
            head.Prev = n;
            head = n;
        }
    }

    // Add a movie at the end
    public void AddAtEnd(Movie movie)
    {
        Node n = new Node(movie);
        if (tail == null)
        {
            head = tail = n;
        }
        else
        {
            tail.Next = n;
            n.Prev = tail;
            tail = n;
        }
    }

    // Add a movie at a specific position
    public void AddAtPosition(Movie movie, int position)
    {
        Node n = new Node(movie);
        if (position == 0)
        {
            AddAtBeginning(movie);
            return;
        }

        Node temp = head;
        for (int i = 0; temp != null && i < position - 1; i++)
        {
            temp = temp.Next;
        }

        if (temp == null)
        {
            Console.WriteLine("Position is out of bounds.");
            return;
        }

        n.Next = temp.Next;
        if (temp.Next != null)
            temp.Next.Prev = n;

        temp.Next = n;
        n.Prev = temp;
    }

    // Remove a movie by Movie Title
    public void RemoveByTitle(string title)
    {
        Node temp = head;

        while (temp != null)
        {
            if (temp.Data.Title == title)
            {
                if (temp.Prev != null)
                    temp.Prev.Next = temp.Next;
                else
                    head = temp.Next;

                if (temp.Next != null)
                    temp.Next.Prev = temp.Prev;
                else
                    tail = temp.Prev;

                Console.WriteLine($"Movie '{title}' removed successfully.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found.");
    }

    // Search for a movie by Director
    public void SearchByDirector(string director)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.Director.ToLower() == director.ToLower())
            {
                Console.WriteLine($"Movie Found: {temp.Data.Title}, Year: {temp.Data.YearOfRelease}, Rating: {temp.Data.Rating}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found.");
    }

    // Search for a movie by Rating
    public void SearchByRating(double rating)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.Rating == rating)
            {
                Console.WriteLine($"Movie Found: {temp.Data.Title}, Director: {temp.Data.Director}, Year: {temp.Data.YearOfRelease}");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found.");
    }

    // Update movie's rating based on Movie Title
    public void UpdateRating(string title, double newRating)
    {
        Node temp = head;
        while (temp != null)
        {
            if (temp.Data.Title == title)
            {
                temp.Data.Rating = newRating;
                Console.WriteLine($"Movie '{title}' rating updated to {newRating}.");
                return;
            }
            temp = temp.Next;
        }

        Console.WriteLine("Movie not found.");
    }

    // Display all movie records in forward order
    public void DisplayForward()
    {
        if (head == null)
        {
            Console.WriteLine("No movies to display.");
            return;
        }

        Node temp = head;
        Console.WriteLine("Movies in Forward Order:");
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Data.Title}, Director: {temp.Data.Director}, Year: {temp.Data.YearOfRelease}, Rating: {temp.Data.Rating}");
            temp = temp.Next;
        }
    }

    // Display all movie records in reverse order
    public void DisplayReverse()
    {
        if (tail == null)
        {
            Console.WriteLine("No movies to display.");
            return;
        }

        Node temp = tail;
        Console.WriteLine("Movies in Reverse Order:");
        while (temp != null)
        {
            Console.WriteLine($"Title: {temp.Data.Title}, Director: {temp.Data.Director}, Year: {temp.Data.YearOfRelease}, Rating: {temp.Data.Rating}");
            temp = temp.Prev;
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        MovieList movieList = new MovieList();

        // Add movies
        movieList.AddAtEnd(new Movie("Ramayan", "Valmiki", 1600, 8.8));
        movieList.AddAtEnd(new Movie("Mahabharat", "Ved Vyasa", 1700, 8.7));
        movieList.AddAtBeginning(new Movie("Geeta", "Ved Vyasa", 1700, 8.6));
        
        // Display movies in forward order
        movieList.DisplayForward();

        // Update movie rating
        Console.WriteLine("\nUpdating rating for 'Inception':");
        movieList.UpdateRating("Inception", 9.0);
        movieList.DisplayForward();

        // Search for a movie by director
        Console.WriteLine("\nSearching for movies directed by 'Christopher Nolan':");
        movieList.SearchByDirector("Christopher Nolan");

        // Remove a movie by title
        Console.WriteLine("\nRemoving 'The Matrix' movie:");
        movieList.RemoveByTitle("The Matrix");
        movieList.DisplayForward();

        // Add movie at a specific position
        Console.WriteLine("\nAdding movie at position 1:");
        movieList.AddAtPosition(new Movie("The Dark Knight", "Christopher", 2008, 9.0), 1);
        movieList.DisplayForward();

        // Display movies in reverse order
        movieList.DisplayReverse();
    }
}
