using HydroProject.Util;

namespace HydroProject.Pages.Components;

public class Summary : HydroComponent
{
    public Summary()
    {
        Subscribe<CountChangedEvent>(Handle);
    }

    public int CountSummanry {  get; set; }

    public void Handle(CountChangedEvent data)
    {
        CountSummanry = data.Count;
    }
}
