using HydroProject.Util;

namespace HydroProject.Pages.Components;

public class CounterEvent : HydroComponent
{
    public int Count { get; set; }

    public void Add()
    { 
        Count++;
        Dispatch(new CountChangedEvent(Count), Scope.Global);
    }
}
