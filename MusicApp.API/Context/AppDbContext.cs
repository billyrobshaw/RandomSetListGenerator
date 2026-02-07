using Microsoft.EntityFrameworkCore;
using MusicApp.API.Models;

namespace MusicApp.API.Context
{
  
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Use the EF entity here, not the DTO
        public DbSet<Music> Musics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Music>()
                .ToTable("MusicInfo"); // maps to your database table
        }
    }
   
}

