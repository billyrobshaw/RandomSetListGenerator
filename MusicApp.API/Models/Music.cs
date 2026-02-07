namespace MusicApp.API.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Artist { get; set; } = null!;
        public string SongTitle { get; set; } = null!;
        public string? Lyrics { get; set; }
        public string? Chords { get; set; }
        public TimeSpan? Duration { get; set; }
    }
}
