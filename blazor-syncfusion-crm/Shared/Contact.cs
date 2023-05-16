using System.Text.Json.Serialization;

namespace BlazorSyncfusionCmr.Shared
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string NickName { get; set; } = string.Empty;
        public string Place { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateDeleted { get; set; }
        [JsonIgnore]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
