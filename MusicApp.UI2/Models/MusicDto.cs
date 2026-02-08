namespace MusicApp.UI2.Models
{
    public class MusicDto
    {
        public int Id { get; set; }
        public string Artist { get; set; } = "";
        public string SongTitle { get; set; } = "";
        public string Lyrics { get; set; } = "";
        public string Chords { get; set; } = "";
        public TimeSpan Duration { get; set; }
    }
}