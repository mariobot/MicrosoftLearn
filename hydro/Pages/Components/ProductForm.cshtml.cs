using System.ComponentModel.DataAnnotations;

namespace HydroProject.Pages.Components;

public class ProductForm : HydroComponent
{
    [Required, MaxLength(50)]
    public string Name { get; set; }

    [Required, MaxLength(50)]
    public string Location { get; set; }

    public string Result { get; set; }

    public async Task Submit()
    {
        if (!Validate())
        {
            Result = string.Empty;
            return;
        }

        Result = $"Your Product {Name} will dispatch at {Location}";
    }
}
