

using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SuggestionAppLibrary.DataAccess;

public class DbConnection : IDbConnection
{
    private readonly IConfiguration configuration;
    private readonly IMongoDatabase db;
    private string connectionId = "MongoDB";
    public string DbName { get; private set; }
    public string CategoryCollectionName { get; private set; } = "categories";
    public string StatusCollectionName { get; private set; } = "statuses";
    public string UserCollectionName { get; private set; } = "users";
    public string SuggestionCollectionName { get; private set; } = "suggestions";

    public MongoClient Client { get; private set; }
    public IMongoCollection<CategoryModel> CategoryCollection { get; private set; }
    public IMongoCollection<StatusModel> StatusCollection { get; private set; }
    public IMongoCollection<UserModel> UserCollection { get; private set; }
    public IMongoCollection<SuggestionModel> SuggestionCollection { get; private set; }

    public DbConnection(IConfiguration configuration)
    {
        this.configuration = configuration;
        Client = new MongoClient(this.configuration.GetConnectionString(connectionId));
        DbName = this.configuration["DatabaseName"];
        db = Client.GetDatabase(DbName);

        CategoryCollection = db.GetCollection<CategoryModel>(CategoryCollectionName);
        StatusCollection = db.GetCollection<StatusModel>(StatusCollectionName);
        UserCollection = db.GetCollection<UserModel>(UserCollectionName);
        SuggestionCollection = db.GetCollection<SuggestionModel>(SuggestionCollectionName);
    }
}
