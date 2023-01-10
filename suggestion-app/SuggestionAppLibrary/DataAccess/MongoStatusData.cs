using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess
{

    public class MongoStatusData : IStatusData
    {
        private readonly IMongoCollection<StatusModel> statuses;
        private readonly IMemoryCache cache;
        private const string cacheName = "StatusData";

        public MongoStatusData(IDbConnection db, IMemoryCache cache)
        {
            this.cache = cache;
            statuses = db.StatusCollection;
        }

        public async Task<List<StatusModel>> GetAllStatuses()
        {
            var output = cache.Get<List<StatusModel>>(cacheName);

            if (output is null)
            {
                var results = await statuses.FindAsync(_ => true);
                output = results.ToList();

                cache.Set(cacheName, output, TimeSpan.FromDays(1));
            }

            return output;
        }

        public Task CreateStatus(StatusModel status)
        {
            return statuses.InsertOneAsync(status);
        }
    }
}
