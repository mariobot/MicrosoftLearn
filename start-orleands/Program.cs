using Orleans.Runtime;
using UrlShortener;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseOrleans(siloBuilder =>
{
    siloBuilder.UseLocalhostClustering();
    siloBuilder.AddMemoryGrainStorage("urls");
    /*siloBuilder.AddAzureBlobGrainStorage("urls",
        // Recommended: Connect to Blob Storage using DefaultAzureCredential
        options =>
        {
            options.ConfigureBlobServiceClient(
                new Uri("https://<your-account-name>.blob.core.windows.net"),
                new DefaultAzureCredential());
        });
    // Connect to Blob Storage using Connection strings
    // options => options.ConfigureBlobServiceClient(connectionString));
    */
});

var app = builder.Build();

app.MapGet("/shortened",
    static async (IGrainFactory grains, HttpRequest request, string url) =>
    {
        var host = $"{request.Scheme}://{request.Host.Value}";

        // Validate the url
        if (string.IsNullOrWhiteSpace(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute) is false)
        {
            return Results.BadRequest($"""
                The URL query string is required and needs to be well formed.
                Consider, ${host}/shorten?url=https://www.microsoft.com.
                """);
        }

        // Create a unique, short ID
        var shortenedRouteSegment = Guid.NewGuid().GetHashCode().ToString("X");

        // Create and persist a grain with the sortened Id and full URL.
        var shorternerGrain = grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);

        await shorternerGrain.SetUrl(url);

        // return the sortened URL for later use
        var resultBuilder = new UriBuilder(host)
        {
            Path = $"/go/{shortenedRouteSegment}"
        };

        return Results.Ok(resultBuilder.Uri);
    });

app.MapGet("/go/{shortenedRouteSegment:required}",
    static async (IGrainFactory grains, string shortenedRouteSegment) =>
    {
        // Retrieve the grain using the shortened ID and url to the original URL
        var shortenerGrain =
            grains.GetGrain<IUrlShortenerGrain>(shortenedRouteSegment);

        var url = await shortenerGrain.GetUrl();

        // Handles missing schemes, defaults to "http://".
        var redirectBuilder = new UriBuilder(url);

        return Results.Redirect(redirectBuilder.Uri.ToString());
    });

app.Run();
