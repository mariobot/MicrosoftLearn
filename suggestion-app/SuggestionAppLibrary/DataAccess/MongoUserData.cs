
namespace SuggestionAppLibrary.DataAccess
{
    public class MongoUserData : IUserData
    {
        private readonly IMongoCollection<UserModel> users;

        public MongoUserData(IDbConnection db)
        {
            users = db.UserCollection;
        }

        public async Task<List<UserModel>> GetUsersAsync()
        {
            var results = await users.FindAsync(_ => true);
            return results.ToList();
        }

        public async Task<UserModel> GetUser(string id)
        {
            var results = await users.FindAsync(x => x.Id == id);
            return results.FirstOrDefault();
        }

        public async Task<UserModel> GetUserFromAuthentication(string objectId)
        {
            var results = await users.FindAsync(x => x.ObjectIdentifier == objectId);
            return results.FirstOrDefault();
        }

        public Task CreateUser(UserModel user)
        {
            return users.InsertOneAsync(user);
        }

        public Task UpdateUser(UserModel user)
        {
            var filter = Builders<UserModel>.Filter.Eq("Id", user.Id);
            return users.ReplaceOneAsync(filter, user, new ReplaceOptions { IsUpsert = true });
        }
    }
}
