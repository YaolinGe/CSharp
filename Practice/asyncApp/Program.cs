using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Calling asynchronous method...");
        var asyncData = await FetchDataAsync();
        Console.WriteLine($"Async data fetched: {asyncData}");

        Console.WriteLine("Calling synchronous method...");
        var syncData = FetchDataSync();
        Console.WriteLine($"Sync data fetched: {syncData}");
    }

    static async Task<string> FetchDataAsync()
    {
        // Simulate a long-running data fetch operation
        await Task.Delay(3000); // Wait for 3 seconds
        Console.WriteLine("Async method has stopped during await.");
        return "Async Sample Data";
    }

    static string FetchDataSync()
    {
        // Simulate a long-running data fetch operation
        Task.Delay(3000).Wait(); // Block for 3 seconds
        Console.WriteLine("Sync method has stopped during wait.");
        return "Sync Sample Data";
    }
}
