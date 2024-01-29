using Microsoft.EntityFrameworkCore;
using UrlShortener.Context;
using UrlShortener.Model;
using UrlShortener.Service;

namespace UrlShortener.Endpoints
{
    public static class ShortenerUrlEndpoint
    {
        public record ShortenUrlRequest(string Url);

        public static void MapShortenerUrlEndpoints(this WebApplication app)
        {
            app.MapPost("shorten", async (
                ShortenUrlRequest requestUrl,
                UrlShorteningService urlShorteningService,
                ApplicationDbContext dbContext,
                HttpContext httpContext) =>
            {
                if (!Uri.TryCreate(requestUrl.Url, UriKind.Absolute, out _))
                {
                    return Results.BadRequest("The specified URL is invalid.");
                }

                var code = await urlShorteningService.GenerateUniqueCode();

                var request = httpContext.Request;

                var shortenedUrl = new ShortenerUrl
                {
                    Id = Guid.NewGuid(),
                    LongUrl = requestUrl.Url,
                    Code = code,
                    ShortUrl = $"{request.Scheme}://{request.Host}/{code}",
                    CreatedOnUtc = DateTime.UtcNow
                };

                dbContext.ShortenedUrls.Add(shortenedUrl);

                await dbContext.SaveChangesAsync();

                return Results.Ok(shortenedUrl.ShortUrl);
            })
            .WithName("PostShortenerUrl")
            .WithOpenApi();

            app.MapGet("{code}", async (string code, ApplicationDbContext dbContext) =>
            {
                var shortenedUrl = await dbContext
                    .ShortenedUrls
                    .SingleOrDefaultAsync(s => s.Code == code);

                if (shortenedUrl is null)
                {
                    return Results.NotFound();
                }

                return Results.Redirect(shortenedUrl.LongUrl);
            })
            .WithName("GetShortenerUrl")
            .WithOpenApi();
        }
    }
}
