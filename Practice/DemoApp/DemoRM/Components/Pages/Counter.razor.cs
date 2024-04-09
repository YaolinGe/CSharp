namespace DemoRM.Components.Pages; 

public partial class Counter
{
    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;
        Console.WriteLine("Counter.razor");
        System.Diagnostics.Debug.WriteLine("Hello");
    }
}
