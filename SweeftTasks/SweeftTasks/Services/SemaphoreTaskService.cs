using System;

public class SemaphoreTaskService
{
    public static async Task SemaphoreSlim()
    {
        var semaphore = new SemaphoreSlim(1, 1);

        var printTask = Task.Run(async () =>
        {
            while (true)
            {
                await semaphore.WaitAsync();
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("1");
                    Console.Write("0");
                }
                finally
                {
                    semaphore.Release();
                }

                await Task.Delay(60); // for better readable console
            }
        });

        var messageTask = Task.Run(async () =>
        {
            while (true)
            {
                await Task.Delay(5000);

                await semaphore.WaitAsync();
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n Neo, you are the chosen one");
                    await Task.Delay(5000);
                }
                finally
                {
                    semaphore.Release();
                }
            }
        });

        await Task.WhenAll(printTask, messageTask);
    }
}
