namespace HydroProject.Pages.Components;

public class RunError : HydroComponent
{
    public void ExecuteRun()
    { 
        throw new Exception("This error message is for testing mode");
    }
}
