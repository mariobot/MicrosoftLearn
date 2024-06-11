namespace HydroProject.Pages.Components;

public class LongPolling : HydroComponent
{
    public int RandomNumber { get; set; }

    [Poll(Interval = 1_000)]
    public async Task Refresh()
    { 
        Random random = new Random();
        RandomNumber = random.Next(0, int.MaxValue);
    }
}
