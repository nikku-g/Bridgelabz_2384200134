using System;

public class Ticket
{
    public int TicketID { get; set; }
    public string CustomerName { get; set; }
    public string MovieName { get; set; }
    public string SeatNumber { get; set; }
    public DateTime BookingTime { get; set; }

    public Ticket(int ticketID, string customerName, string movieName, string seatNumber, DateTime bookingTime)
    {
        TicketID = ticketID;
        CustomerName = customerName;
        MovieName = movieName;
        SeatNumber = seatNumber;
        BookingTime = bookingTime;
    }
}

public class TicketReservationSystem
{
    public class Node
    {
        public Ticket Data;
        public Node Next;

        public Node(Ticket data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private Node tail;
    private int ticketCount;

    public TicketReservationSystem()
    {
        head = null;
        tail = null;
        ticketCount = 0;
    }

    // Add a new ticket reservation at the end of the circular list
    public void AddTicket(int ticketID, string customerName, string movieName, string seatNumber, DateTime bookingTime)
    {
        Ticket newTicket = new Ticket(ticketID, customerName, movieName, seatNumber, bookingTime);
        Node newNode = new Node(newTicket);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
            newNode.Next = head; // Circular connection
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head; // Circular connection
        }
        ticketCount++;
        Console.WriteLine($"Ticket {ticketID} booked for {customerName}.");
    }

    // Remove a ticket by Ticket ID
    public void RemoveTicket(int ticketID)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets to remove.");
            return;
        }

        Node temp = head;
        Node prev = null;

        // Check if the ticket to remove is the head
        if (temp.Data.TicketID == ticketID)
        {
            if (head == tail) // Only one node in the list
            {
                head = null;
                tail = null;
            }
            else
            {
                tail.Next = temp.Next;
                head = temp.Next;
            }
            ticketCount--;
            Console.WriteLine($"Ticket {ticketID} removed.");
            return;
        }

        // Search for the ticket to remove
        do
        {
            prev = temp;
            temp = temp.Next;

            if (temp.Data.TicketID == ticketID)
            {
                prev.Next = temp.Next;
                if (temp == tail) tail = prev; // Update the tail if the last node is removed
                ticketCount--;
                Console.WriteLine($"Ticket {ticketID} removed.");
                return;
            }

        } while (temp != head); // Continue until we loop back to the head

        Console.WriteLine("Ticket not found.");
    }

    // Display the current tickets in the list
    public void DisplayTickets()
    {
        if (head == null)
        {
            Console.WriteLine("No tickets to display.");
            return;
        }

        Node temp = head;
        do
        {
            Console.WriteLine($"Ticket ID: {temp.Data.TicketID}, Customer: {temp.Data.CustomerName}, Movie: {temp.Data.MovieName}, Seat: {temp.Data.SeatNumber}, Booking Time: {temp.Data.BookingTime}");
            temp = temp.Next;
        } while (temp != head);
    }

    // Search for a ticket by Customer Name or Movie Name
    public void SearchTicket(string searchTerm)
    {
        if (head == null)
        {
            Console.WriteLine("No tickets available.");
            return;
        }

        Node temp = head;
        bool found = false;
        do
        {
            if (temp.Data.CustomerName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) || temp.Data.MovieName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Ticket ID: {temp.Data.TicketID}, Customer: {temp.Data.CustomerName}, Movie: {temp.Data.MovieName}, Seat: {temp.Data.SeatNumber}, Booking Time: {temp.Data.BookingTime}");
                found = true;
            }
            temp = temp.Next;
        } while (temp != head);

        if (!found)
        {
            Console.WriteLine("No tickets found with the given search term.");
        }
    }

    // Calculate the total number of booked tickets
    public void GetTotalTickets()
    {
        Console.WriteLine($"Total booked tickets: {ticketCount}");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        TicketReservationSystem system = new TicketReservationSystem();

        // Add tickets
        system.AddTicket(1, "Alice", "Avatar 2", "A1", DateTime.Now);
        system.AddTicket(2, "Bob", "Titanic", "B2", DateTime.Now);
        system.AddTicket(3, "Charlie", "Avatar 2", "C3", DateTime.Now);

        // Display all tickets
        Console.WriteLine("All Tickets:");
        system.DisplayTickets();

        // Remove a ticket
        system.RemoveTicket(2);

        // Display all tickets after removal
        Console.WriteLine("\nTickets after removal:");
        system.DisplayTickets();

        // Search for tickets by customer or movie
        Console.WriteLine("\nSearching for tickets related to 'Avatar 2':");
        system.SearchTicket("Avatar 2");

        // Get total booked tickets
        system.GetTotalTickets();
    }
}
