namespace BlazorCrudSSR.Models
{
    public class VideoGame
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Publisher { get; set; }

        public int? ReleaseDate { get; set; }
    }
}
