using System;
using System.Collections.Generic;

public class Task
{
    public int TaskID { get; set; }
    public string TaskName { get; set; }
    public int Priority { get; set; }
    public DateTime DueDate { get; set; }

    public Task(int taskID, string taskName, int priority, DateTime dueDate)
    {
        TaskID = taskID;
        TaskName = taskName;
        Priority = priority;
        DueDate = dueDate;
    }
}


public class Node
{
    public Task Data;
    public Node Next;

    public Node(Task data)
    {
        Data = data;
        Next = null;
    }
}


public class TaskScheduler
{
    private Node head;

    public TaskScheduler()
    {
        head = null;
    }

    // Add a task at the beginning
    public void AddAtBeginning(Task task)
    {
        Node newNode = new Node(task);
        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
        }
        else
        {
            Node temp = head;
            while (temp.Next != head) // Loop to the last node
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Next = head;
            head = newNode;
        }
    }

    // Add a task at the end
    public void AddAtEnd(Task task)
    {
        Node newNode = new Node(task);
        if (head == null)
        {
            head = newNode;
            newNode.Next = head;
        }
        else
        {
            Node temp = head;
            while (temp.Next != head) // Loop to the last node
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Next = head;
        }
    }

    // Add a task at a specific position
    public void AddAtPosition(Task task, int position)
    {
        Node newNode = new Node(task);

        if (position == 0)
        {
            AddAtBeginning(task);
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

        newNode.Next = temp.Next;
        temp.Next = newNode;
    }

    // Remove a task by Task ID
    public void RemoveByTaskID(int taskID)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        // If head node itself holds the task ID
        if (head.Data.TaskID == taskID)
        {
            if (head.Next == head) // Only one task exists
            {
                head = null;
            }
            else
            {
                Node temp = head;
                while (temp.Next != head)
                {
                    temp = temp.Next;
                }
                temp.Next = head.Next;
                head = head.Next;
            }
            Console.WriteLine($"Task with Task ID {taskID} has been removed.");
            return;
        }

        // Search for task in the list
        Node current = head;
        while (current.Next != head && current.Next.Data.TaskID != taskID)
        {
            current = current.Next;
        }

        if (current.Next == head)
        {
            Console.WriteLine("Task not found.");
        }
        else
        {
            current.Next = current.Next.Next;
            Console.WriteLine($"Task with Task ID {taskID} has been removed.");
        }
    }

    // View the current task and move to the next task in the circular list
    public void ViewNextTask()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Console.WriteLine($"Current Task: {head.Data.TaskName}, Due: {head.Data.DueDate}, Priority: {head.Data.Priority}");
        head = head.Next; // Move to next task in the circular list
    }

    // Display all tasks starting from the head node
    public void DisplayAllTasks()
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Node temp = head;
        do
        {
            Console.WriteLine($"Task ID: {temp.Data.TaskID}, Name: {temp.Data.TaskName}, Priority: {temp.Data.Priority}, Due Date: {temp.Data.DueDate}");
            temp = temp.Next;
        } while (temp != head);
    }

    // Search for a task by Priority
    public void SearchByPriority(int priority)
    {
        if (head == null)
        {
            Console.WriteLine("No tasks available.");
            return;
        }

        Node temp = head;
        do
        {
            if (temp.Data.Priority == priority)
            {
                Console.WriteLine($"Task found: {temp.Data.TaskName}, ID: {temp.Data.TaskID}, Due Date: {temp.Data.DueDate}");
                return;
            }
            temp = temp.Next;
        } while (temp != head);

        Console.WriteLine("No tasks found with the given priority.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        TaskScheduler scheduler = new TaskScheduler();

        // Add tasks to the scheduler
        scheduler.AddAtEnd(new Task(101, "Task 1", 1, DateTime.Now.AddDays(1)));
        scheduler.AddAtEnd(new Task(102, "Task 2", 3, DateTime.Now.AddDays(2)));
        scheduler.AddAtBeginning(new Task(100, "Task 0", 2, DateTime.Now.AddDays(3)));

        // Display all tasks
        Console.WriteLine("All tasks in the scheduler:");
        scheduler.DisplayAllTasks();

        // View next task (circular list functionality)
        Console.WriteLine("\nViewing next task:");
        scheduler.ViewNextTask();

        // Search task by priority
        Console.WriteLine("\nSearching for tasks with Priority 3:");
        scheduler.SearchByPriority(3);

        // Remove task by Task ID
        Console.WriteLine("\nRemoving task with Task ID 101:");
        scheduler.RemoveByTaskID(101);
        scheduler.DisplayAllTasks();

        // Add a task at a specific position
        Console.WriteLine("\nAdding a task at position 1:");
        scheduler.AddAtPosition(new Task(103, "Task 3", 1, DateTime.Now.AddDays(4)), 1);
        scheduler.DisplayAllTasks();

        // Viewing next task again (circular behavior)
        Console.WriteLine("\nViewing next task:");
        scheduler.ViewNextTask();
    }
}
