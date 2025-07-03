using System.Diagnostics;
public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //first I created a variable to append my result in each intereaction
        double[] result = new double[length];
        // The code iter for each element making sure to cover all of them
        for (int i = 0; i < length; i++)
        {
            //then I made the calculation multiplying the number with the idex, and sum 1 to keep multiplying until the lenght o parameter
            result[i] = number * (i + 1);
        }

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        //declare a variable to count the data
        int n = data.Count;

        //then check if the amount == data, so we don't have to rotate the list
        if (amount == n || amount == 0)
            return;

        // This part gets the split the data to know which one goes first and what last
        List<int> tail = data.GetRange(n - amount, amount);
        List<int> head = data.GetRange(0, n - amount);

        //clear the list and organize it again using our previous variables
        data.Clear();
        data.AddRange(tail);
        data.AddRange(head);
    }
}
