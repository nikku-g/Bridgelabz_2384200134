using System;
using System.Threading;
using NUnit.Framework;

public class TaskManager
{
    public void LongRunningTask()
    {
        Thread.Sleep(3000); // Simulates a long-running task (3 seconds)
    }
}

[TestFixture]
public class TaskManagerTests
{
    private TaskManager _taskManager;

    [SetUp]
    public void Setup()
    {
        _taskManager = new TaskManager();
    }

    [Test]
    [Timeout(2000)] // Fails if execution exceeds 2 seconds
    public void LongRunningTask_ShouldFailDueToTimeout()
    {
        _taskManager.LongRunningTask();
    }
}
