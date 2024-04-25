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
        }
    }
}
