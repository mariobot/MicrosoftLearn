namespace SuggestionAppUI;

public static class RegisterServices
{
    public static void ConfiguraServices(this WebApplicationBuilder builder)
    {
        // Add services to the container.
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
    }
}
