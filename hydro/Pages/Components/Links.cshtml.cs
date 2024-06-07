using Microsoft.AspNetCore.Mvc;

namespace HydroProject.Pages.Components;

public class Links: HydroComponent
{
    public void CallPrivancyLink()
    {
        Location(Url.Page("/Privacy"));
    }
}
