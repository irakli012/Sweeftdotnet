using SweeftTasks.Algorithms;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Task 1 --- Palindrome");
        Console.WriteLine(Palindrome.IsPalindrome("car"));
        Console.WriteLine(Palindrome.IsPalindrome("abcba"));

        Console.WriteLine();
        Console.WriteLine("Task 2 --- Coins");
        Console.WriteLine(CoinsChange.MinSplit(120));
        Console.WriteLine(CoinsChange.MinSplit(50));
    }
}