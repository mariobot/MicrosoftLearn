using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuggestionAppLibrary.Models
{
    public class BasicUserModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public BasicUserModel()
        {

        }

        public BasicUserModel(UserModel user)
        {
            Id = user.Id;
            DisplayName = user.DisplayName;
        }
    }
}
