using System;
using System.Collections.Generic;

public class Process
{
    public int ProcessID { get; set; }
    public int BurstTime { get; set; }
    public int RemainingTime { get; set; }
    public int Priority { get; set; }
    public int WaitingTime { get; set; }
    public int TurnaroundTime { get; set; }

    public Process(int processID, int burstTime, int priority)
    {
        ProcessID = processID;
        BurstTime = burstTime;
        RemainingTime = burstTime;
        Priority = priority;
        WaitingTime = 0;
        TurnaroundTime = 0;
    }
}

public class CircularLinkedList
{
    public class Node
    {
        public Process Data;
        public Node Next;

        public Node(Process data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private Node tail;

    public CircularLinkedList()
    {
        head = null;
        tail = null;
    }

    // Add a new process at the end of the circular list
    public void AddProcess(int processID, int burstTime, int priority)
    {
        Process process = new Process(processID, burstTime, priority);
        Node newNode = new Node(process);

        if (head == null)
        {
            head = newNode;
            tail = newNode;
            newNode.Next = head; // Circular link
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
            tail.Next = head; // Circular link
        }
    }

    // Remove a process by Process ID
    public void RemoveProcess(int processID)
    {
        if (head == null)
        {
            Console.WriteLine("No processes to remove.");
            return;
        }

        Node temp = head;
        Node prev = null;

        // If the process to remove is the head
        if (head.Data.ProcessID == processID)
        {
            if (head == head.Next) // Only one node in the list
            {
                head = null;
                tail = null;
            }
            else
            {
                tail.Next = head.Next;
                head = head.Next;
            }
            Console.WriteLine($"Process with ID {processID} removed.");
            return;
        }

        // Search for the process in the list
        do
        {
            prev = temp;
            temp = temp.Next;

            if (temp.Data.ProcessID == processID)
            {
                prev.Next = temp.Next;
                if (temp == tail)
                {
                    tail = prev; // Update tail if last node is removed
                }
                Console.WriteLine($"Process with ID {processID} removed.");
                return;
            }

        } while (temp != head);

        Console.WriteLine("Process not found.");
    }

    // Simulate the Round Robin Scheduling Algorithm with a fixed time quantum
    public void RoundRobinScheduling(int timeQuantum)
    {
        if (head == null)
        {
            Console.WriteLine("No processes to schedule.");
            return;
        }

        Node temp = head;
        int totalWaitingTime = 0;
        int totalTurnaroundTime = 0;
        int completedProcesses = 0;
        int totalProcesses = 0;

        // Calculate total processes
        Node countNode = head;
        do
        {
            totalProcesses++;
            countNode = countNode.Next;
        } while (countNode != head);

        // Round Robin Scheduling Loop
        while (completedProcesses < totalProcesses)
        {
            if (temp.Data.RemainingTime > 0)
            {
                int executionTime = Math.Min(timeQuantum, temp.Data.RemainingTime);
                temp.Data.RemainingTime -= executionTime;

                // Update turnaround time and waiting time
                temp.Data.TurnaroundTime += executionTime;
                temp.Data.WaitingTime = temp.Data.TurnaroundTime - temp.Data.BurstTime;

                if (temp.Data.RemainingTime == 0) // Process finished
                {
                    completedProcesses++;
                }
            }

            Console.WriteLine($"Process {temp.Data.ProcessID} executed for {Math.Min(timeQuantum, temp.Data.RemainingTime + timeQuantum)} ms");

            temp = temp.Next;
        }

        // Display the processes and their waiting and turnaround times
        Console.WriteLine("\nProcess Information (After Round Robin Scheduling):");
        temp = head;
        do
        {
            Console.WriteLine($"Process {temp.Data.ProcessID}: Waiting Time = {temp.Data.WaitingTime}, Turnaround Time = {temp.Data.TurnaroundTime}");
            totalWaitingTime += temp.Data.WaitingTime;
            totalTurnaroundTime += temp.Data.TurnaroundTime;
            temp = temp.Next;
        } while (temp != head);

        // Calculate and display average waiting time and average turnaround time
        Console.WriteLine($"\nAverage Waiting Time: {(float)totalWaitingTime / totalProcesses}");
        Console.WriteLine($"Average Turnaround Time: {(float)totalTurnaroundTime / totalProcesses}");
    }

    // Display the list of processes in the circular queue
    public void DisplayProcesses()
    {
        if (head == null)
        {
            Console.WriteLine("No processes in the list.");
            return;
        }

        Node temp = head;
        Console.WriteLine("\nProcess List (Circular Queue):");
        do
        {
            Console.WriteLine($"Process ID: {temp.Data.ProcessID}, Burst Time: {temp.Data.BurstTime}, Remaining Time: {temp.Data.RemainingTime}, Priority: {temp.Data.Priority}");
            temp = temp.Next;
        } while (temp != head);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        CircularLinkedList processQueue = new CircularLinkedList();

        // Add processes
        processQueue.AddProcess(1, 10, 1);
        processQueue.AddProcess(2, 5, 2);
        processQueue.AddProcess(3, 8, 3);

        // Display processes before scheduling
        processQueue.DisplayProcesses();

        // Simulate Round Robin Scheduling with a time quantum of 4 ms
        processQueue.RoundRobinScheduling(4);

        // Display processes after scheduling
        processQueue.DisplayProcesses();
    }
}
