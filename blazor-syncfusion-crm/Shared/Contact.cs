using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorSyncfusionCmr.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;

        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateCreated { get; set; } = DateTime.Now;

        [JsonIgnore]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
