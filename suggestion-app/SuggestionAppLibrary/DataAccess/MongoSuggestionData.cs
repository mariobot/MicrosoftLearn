using Microsoft.Extensions.Caching.Memory;

namespace SuggestionAppLibrary.DataAccess
{
    public class MongoSuggestionData : ISuggestionData
    {
        private readonly IDbConnection db;
        private readonly IUserData userData;
        private readonly IMemoryCache cache;
        private readonly IMongoCollection<SuggestionModel> suggestions;
        private const string CacheName = "SuggestionData";

        public MongoSuggestionData(IDbConnection db, IUserData userData, IMemoryCache cache)
        {
            this.db = db;
            this.userData = userData;
            this.cache = cache;
            suggestions = db.SuggestionCollection;
        }

        public async Task<List<SuggestionModel>> GetAllSuggestions()
        {
            var output = cache.Get<List<SuggestionModel>>(CacheName);

            if (output is null)
            {
                var results = await suggestions.FindAsync(x => x.Archived == false);
                output = results.ToList();

                cache.Set(CacheName, output, TimeSpan.FromMinutes(1));
            }

            return output;
        }

        public async Task<List<SuggestionModel>> GetUsersSuggestions(string userId)
        {
            var output = cache.Get<List<SuggestionModel>>(userId);
            if (output is null)
            {
                var results = await suggestions.FindAsync(x => x.Author.Id == userId);
                output = results.ToList();

                cache.Set(userId, output, TimeSpan.FromMinutes(1));
            }

            return output;        
        }

        public async Task<List<SuggestionModel>> GetAllApprovedSuggestions()
        {
            var output = await GetAllSuggestions();
            return output.Where(x => x.ApprovedForRelease).ToList();
        }

        public async Task<SuggestionModel> GetSuggestion(string id)
        {
            var results = await suggestions.FindAsync(x => x.Id == id);
            return results.FirstOrDefault();
        }

        public async Task<List<SuggestionModel>> GetAllSuggestionsWaitingForApproval()
        {
            var output = await GetAllSuggestions();
            return output.Where(x => x.ApprovedForRelease == false && x.Rejected == false).ToList();
        }

        public async Task UpdateSuggestion(SuggestionModel suggestion)
        {
            await suggestions.ReplaceOneAsync(x => x.Id == suggestion.Id, suggestion);
            cache.Remove(CacheName);
        }

        public async Task UpvoteSuggestion(string suggestionId, string userId)
        {
            var client = db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(this.db.DbName);
                var suggestionsInTransaction = db.GetCollection<SuggestionModel>(this.db.SuggestionCollectionName);
                var suggestion = (await suggestionsInTransaction.FindAsync(x => x.Id == suggestionId)).First();

                bool isUpvote = suggestion.UserVotes.Add(userId);

                if (isUpvote == false)
                {
                    suggestion.UserVotes.Remove(userId);
                }

                await suggestionsInTransaction.ReplaceOneAsync(x => x.Id == suggestionId, suggestion);
                var usersInTransaction = db.GetCollection<UserModel>(this.db.UserCollectionName);
                var user = await userData.GetUser(suggestion.Author.Id);

                if (isUpvote)
                {
                    user.VotedOnSuggestions.Add(new BasicSuggestionModel(suggestion));
                }
                else
                {
                    var suggestionToRemove = user.VotedOnSuggestions.Where(x => x.Id == suggestionId).First();
                    user.VotedOnSuggestions.Remove(suggestionToRemove);
                }

                await usersInTransaction.ReplaceOneAsync(x => x.Id == userId, user);

                await session.CommitTransactionAsync();

                cache.Remove(CacheName);
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }

        public async Task CreateSuggestion(SuggestionModel suggestion)
        {
            var client = db.Client;
            using var session = await client.StartSessionAsync();
            session.StartTransaction();

            try
            {
                var db = client.GetDatabase(this.db.DbName);
                var suggestionsInTransaction = db.GetCollection<SuggestionModel>(this.db.SuggestionCollectionName);
                await suggestionsInTransaction.InsertOneAsync(suggestion);

                var usersInTransaction = db.GetCollection<UserModel>(this.db.UserCollectionName);
                var user = await userData.GetUser(suggestion.Author.Id);
                user.AuthoredSuggestions.Add(new BasicSuggestionModel(suggestion));
                await usersInTransaction.ReplaceOneAsync(x => x.Id == user.Id, user);

                await session.CommitTransactionAsync();
            }
            catch (Exception ex)
            {
                await session.AbortTransactionAsync();
                throw;
            }
        }
    }
}
