using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApp.API.Context;
using MusicApp.API.Models;

namespace MusicApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MusicController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MusicController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicDto>>> GetMusic()
        {
            // Step 1: fetch data into memory
            var musicList = await _context.Musics.ToListAsync();

            // Step 2: project to DTO and format TimeSpan
            var result = musicList.Select(m => new MusicDto
            {
                Id = m.Id,
                Artist = m.Artist,
                SongTitle = m.SongTitle,
                Lyrics = m.Lyrics,
                Chords = m.Chords,
                Duration = (TimeSpan)m.Duration // no HasValue needed
            }).ToList();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddMusicQuery(
            [FromQuery] int id,
            [FromQuery] string artist,
            [FromQuery] string songTitle,
            [FromQuery] string? lyrics,
            [FromQuery] string? chords,
            [FromQuery] TimeSpan? duration // "hh:mm:ss"
        )
        {
            if (string.IsNullOrEmpty(artist) || string.IsNullOrEmpty(songTitle))
                return BadRequest("Artist and SongTitle are required.");

            //if (!string.IsNullOrEmpty(duration) && !TimeSpan.TryParse(duration, out _))
            //    return BadRequest("Invalid duration format. Use hh:mm:ss");

            var music = new Music
            {
                Id = id,
                Artist = artist,
                SongTitle = songTitle,
                Lyrics = lyrics,
                Chords = chords,
                Duration = duration
            };

            _context.Musics.Add(music);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Song added successfully!", id = music.Id });
        }
    }
}
