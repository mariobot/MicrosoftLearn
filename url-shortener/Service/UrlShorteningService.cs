using Microsoft.EntityFrameworkCore;
using UrlShortener.Context;
using UrlShortener.Model;

namespace UrlShortener.Service
{
    public class UrlShorteningService
    {
        
        private readonly ApplicationDbContext dbContext;
        private readonly Random _random = new Random();

        public UrlShorteningService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<string> GenerateUniqueCode()
        {
            var codeChars = new char[ShortLinkSettings.Length];
            int maxValue = ShortLinkSettings.Alphabet.Length;

            while (true)
            {
                for (var i = 0; i < ShortLinkSettings.Length; i++)
                {
                    var randomIndex = _random.Next(maxValue);

                    codeChars[i] = ShortLinkSettings.Alphabet[randomIndex];
                }

                var code = new string(codeChars);

                if (!await dbContext.ShortenedUrls.AnyAsync(s => s.Code == code))
                {
                    return code;
                }
            }
        }
    }
}
