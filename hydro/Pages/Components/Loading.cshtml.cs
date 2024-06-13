namespace HydroProject.Pages.Components;

public class Loading : HydroComponent
{
    public int ValueRange { get; set; } = 1;
    
    public async Task Submit()
    {
        await Task.Delay(ValueRange*1000);
    }
}
