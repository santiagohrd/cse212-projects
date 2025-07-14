using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three elements and check if they are correctly added.
    // Expected Result: ToString should show elements in insertion order with their priority.
    // Defect(s) Found: None 
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("customer1", 2);
        priorityQueue.Enqueue("customer2", 5);
        priorityQueue.Enqueue("customer3", 1);

        string expected = "[customer1 (Pri:2), customer2 (Pri:5), customer3 (Pri:1)]";
        Assert.AreEqual(expected, priorityQueue.ToString());
    }

    [TestMethod]
    // Scenario: Dequeue from a queue where one item has the highest priority.
    // Expected Result: The item with highest priority should be returned and removed.
    // Defect(s) Found: 
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("customer1", 2);
        priorityQueue.Enqueue("customer2", 5);
        priorityQueue.Enqueue("customer3", 1);

        string value = priorityQueue.Dequeue();
        Assert.AreEqual("customer2", value);

    }

    // Add more test cases as needed below.

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority.
    // Expected Result: The one that appears first (FIFO) should be dequeued.
    // Defect(s) Found: 
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("customer1", 5);
        priorityQueue.Enqueue("customer2", 2);
        priorityQueue.Enqueue("customer3", 5);

        string value = priorityQueue.Dequeue();
        Assert.AreEqual("customer1", value);

    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: Should throw InvalidOperationException.
    // Defect(s) Found: 
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        });

    }







}