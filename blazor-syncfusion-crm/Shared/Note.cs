using System.ComponentModel.DataAnnotations;

namespace BlazorSyncfusionCmr.Shared
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public required string Text { get; set; }
        public int? ContactId { get; set; }
        public Contact? Contact { get; set; }
        public DateTime DateCreated { get; set;} = DateTime.Now;
    }
}
