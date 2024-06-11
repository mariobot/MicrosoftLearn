namespace HydroProject.Pages.Components;

public class Toasts: HydroComponent
{
    public List<Toast> ToastsList { get; set; } = new();

    public Toasts()
    {
        Subscribe<UnhandledHydroError>(Handle);
    }

    private void Handle(UnhandledHydroError data) =>
        ToastsList.Add(new Toast(
            Id: Guid.NewGuid().ToString("N"),
            Message: data.Message,
            Type: ToastType.Error
        ));

    public void Close(string id) =>
        ToastsList.RemoveAll(t => t.Id == id);

    public record Toast(string Id, string Message, ToastType Type);

    public enum ToastType
    { 
        Error,
        Success,
        Log,
        Information
    }
}
