using SweeftTasks.Algorithms;
using SweeftTasks.Data;
using SweeftTasks.Services;

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

        Console.WriteLine();
        Console.WriteLine("Task 3 --- Smallest positive missing number");
        Console.WriteLine(SmallestMissing.NotContains(new int[] { 1, 3, 4, 5 }));
        Console.WriteLine(SmallestMissing.NotContains(new int[] {-3, -4, 2, 6}));

        Console.WriteLine();
        Console.WriteLine("Task 4 --- Parentesis check");
        Console.WriteLine(Parentheses.IsProperly("() (()"));
        Console.WriteLine(Parentheses.IsProperly("() ()"));

        Console.WriteLine();
        Console.WriteLine("Task 5 --- Count stair variants");
        Console.WriteLine(StairVariants.CountVariants(2));
        Console.WriteLine(StairVariants.CountVariants(5));

        Console.WriteLine();
        Console.WriteLine("Task 7 --- Teachers for giorgi");

        using (var context = new SchoolDbContext())
        {
            context.Database.EnsureCreated();
            SeedData.Seed(context);
        }

        var teacherService = new TeacherService();
        var teachersForGiorgi = teacherService.GetAllTeachersByStudent("Giorgi");

        foreach (var teacher in teachersForGiorgi)
        {
            Console.WriteLine($"{teacher.FirstName} {teacher.LastName}  ({teacher.Subject})");
        }
    }
}   