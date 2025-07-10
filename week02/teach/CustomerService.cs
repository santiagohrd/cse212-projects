/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add 4 customers to a queue with a max size of 3
        // Expected Result: Only 3 customers should be added; the 4th should trigger an error message
        Console.WriteLine("Test 1");

        var service = new CustomerService(2);

        var input1 = new StringReader("Ana\n101\nProblema A\n");
        Console.SetIn(input1);
        service.AddNewCustomer();

        var input2 = new StringReader("Luis\n102\nProblema B\n");
        Console.SetIn(input2);
        service.AddNewCustomer();

        var input3 = new StringReader("Sofia\n103\nProblema C\n");
        Console.SetIn(input3);
        service.AddNewCustomer();

        var input4 = new StringReader("Pedro\n104\nProblema D\n");
        Console.SetIn(input4);
        service.AddNewCustomer();

        Console.WriteLine(service);


        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add 2 customers and serve one
        // Expected Result: Should display the first customer and leave one in the queue
        Console.WriteLine("Test 2");

        var service2 = new CustomerService(5);

        var input5 = new StringReader("Ana\n101\nConsulta general\n");
        Console.SetIn(input5);
        service2.AddNewCustomer();

        var input6 = new StringReader("Luis\n102\nProblema técnico\n");
        Console.SetIn(input6);
        service2.AddNewCustomer();

        service2.ServeCustomer();

        Console.WriteLine(service2);

        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Add more Test Cases As Needed Below


        // Test 3
        // Scenario: Call ServeCustomer on an empty queue
        // Expected Result: An error message should be displayed when trying to serve from an empty queue
        Console.WriteLine("Test 3");

        var service3 = new CustomerService(5);

        service3.ServeCustomer(); 
        
        Console.WriteLine("=================");
    }


    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {

        if (_queue.Count == 0) {
        Console.WriteLine("No customers in the queue.");
        return;
    }
        var customer = _queue[0];     
        _queue.RemoveAt(0);
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}