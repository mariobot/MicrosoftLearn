namespace UrlShortener
{
    [GenerateSerializer]
    public sealed record class UrlDetails
    {
        [Id(0)]
        public string FullUrl { get; set; } = "";

        [Id(1)]
        public string ShortenedRouteSegment { get; set; } = "";
    }
}
