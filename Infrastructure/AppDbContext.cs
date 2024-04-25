using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class AppDbContext : DbContext 
    {
        //parent entities
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Region> Regions { get; set; }


        //child entities

        public DbSet<Game> Games { get; set; }

        public DbSet<Game_Publisher> Game_Publishers { get; set; }
        
        public DbSet<Game_Platform> Game_Platforms { get; set; }
        public DbSet<Region_Sales> Region_Sales { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //provide your own database con string
            optionsBuilder.UseSqlServer("Data Source=HP;Initial Catalog=video_gamesDb;Integrated Security=True;Trust Server Certificate=True");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region_Sales>()
                .HasKey(x => new { x.RegionId, x.Game_PlatformId });


            modelBuilder.Entity<Genre>()
                .HasData(new Genre() { Id = 1 ,Genre_Name = "RPG"}, new Genre() {Id = 2 ,Genre_Name = "RTS"},
                new Genre() {Id = 3 ,Genre_Name = "Shooters"}, new Genre() { Id = 4 ,Genre_Name = "Sports"},
                new Genre() { Id = 5 ,Genre_Name = "Simulators"});

            modelBuilder.Entity<Game>()
                .HasData(new Game() {Id = 1 , GenreId = 1, Game_Name = "The Witcher" },
                new Game() { Id = 2 ,GenreId = 2, Game_Name = "Warcraft" },
                new Game() { Id = 3 ,GenreId = 3, Game_Name = "Call of Duty" },
                new Game() { Id = 4 ,GenreId = 4, Game_Name = "Fifa" },
                new Game() { Id = 5 ,GenreId = 5, Game_Name = "Farming Simulator" });
        }
    }
}
