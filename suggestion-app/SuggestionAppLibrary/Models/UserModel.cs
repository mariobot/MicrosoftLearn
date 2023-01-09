
namespace SuggestionAppLibrary.Models
{
    public class UserModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string ObjectIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public List<BasicSuggestionModel> AuthoredSuggestions { get; set; } = new();
        
        public List<BasicSuggestionModel> VotedOnSuggestions { get; set; } = new();
    }
}
