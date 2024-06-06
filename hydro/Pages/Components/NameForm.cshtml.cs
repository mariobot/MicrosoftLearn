namespace HydroProject.Pages.Components;

public class NameForm : HydroComponent
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override void Bind(PropertyPath property, object value)
    {
        if (property.Name == nameof(FirstName)) 
        { 
            FirstName = "*"+(string)value+"*";
        }
    }
}
