using Microsoft.AspNetCore.WebUtilities;
using MusicApp.UI2.Models;
using System.Net.Http.Json;

namespace MusicApp.UI2.Services
{
    public class MusicService
    {
        private readonly HttpClient _http;

        public MusicService(HttpClient http)
        {
            _http = http;
        }

        // Existing
        public async Task<List<MusicDto>> GetByArtist(string artist)
        {
            return await _http.GetFromJsonAsync<List<MusicDto>>($"api/music/artist/{artist}")
                   ?? new List<MusicDto>();
        }

        // New method to get all music
        public async Task<List<MusicDto>> GetAllMusic()
        {
            return await _http.GetFromJsonAsync<List<MusicDto>>($"api/music")
                   ?? new List<MusicDto>();
        }
        public async Task<bool> AddMusicAsync(MusicDto music)
        {
            var query = new Dictionary<string, string?>
            {
                ["artist"] = music.Artist,
                ["songTitle"] = music.SongTitle,
                ["lyrics"] = music.Lyrics,
                ["chords"] = music.Chords,
                ["duration"] = music.Duration.ToString()
            };

            var url = QueryHelpers.AddQueryString("api/music", query);
            var response = await _http.PostAsync(url, null);

            return response.IsSuccessStatusCode;
        }


    }
}