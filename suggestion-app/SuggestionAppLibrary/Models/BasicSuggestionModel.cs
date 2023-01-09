using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionAppLibrary.Models
{
    public class BasicSuggestionModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }

        public BasicSuggestionModel()
        {

        }

        public BasicSuggestionModel(SuggestionModel suggestion)
        {
            Id = suggestion.Id;
            Title = suggestion.Suggestion;
        }
    }
}
