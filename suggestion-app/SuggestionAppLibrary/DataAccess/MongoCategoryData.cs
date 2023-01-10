using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess
{
    public class MongoCategoryData : ICategoryData
    {
        private readonly IMongoCollection<CategoryModel> categories;
        private readonly IMemoryCache cache;
        private const string cacheName = "CategoryData";

        public MongoCategoryData(IDbConnection db, IMemoryCache cache)
        {
            this.cache = cache;
            categories = db.CategoryCollection;
        }

        public async Task<List<CategoryModel>> GetAllCategories()
        {
            var output = cache.Get<List<CategoryModel>>(cacheName);
            if (output is null)
            {
                var results = await categories.FindAsync(_ => true);
                output = results.ToList();

                cache.Set(cacheName, output, TimeSpan.FromDays(1));
            }

            return output;
        }

        public Task CreateCategory(CategoryModel category)
        {
            return categories.InsertOneAsync(category);
        }
    }
}
