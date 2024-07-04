using BCrypt.Net;
using Infrastructure.Entities;
using Infrastructure.Entities.User_Roles_Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Infrastructure
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        //parent entities
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Region> Regions { get; set; }


        //child entities

        public DbSet<Game> Games { get; set; }

        //public DbSet<Game_Publisher> Game_Publishers { get; set; }
        
        public DbSet<Game_Platform> Game_Platforms { get; set; }
        public DbSet<Region_Sales> Region_Sales { get; set; }

        //user_roles entites

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }

        public DbSet<RefreshTokenInfo> RefreshTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //provide your own database con string
            //optionsBuilder.UseSqlServer("Data Source=HP;Initial Catalog=video_gamesDb;Integrated Security=True;Trust Server Certificate=True");
            optionsBuilder.UseSqlServer("Data Source = HP;Initial Catalog=video_gamesDb2;Integrated Security=True;Trust Server Certificate=True");
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region_Sales>()
                .HasKey(x => new { x.RegionId, x.Game_PlatformId });


            
            //Create data

            modelBuilder.Entity<Genre>()
                .HasData(new Genre() { Id = 1 ,Genre_Name = "RPG"}, new Genre() {Id = 2 ,Genre_Name = "RTS"},
                new Genre() {Id = 3 ,Genre_Name = "Shooters"}, new Genre() { Id = 4 ,Genre_Name = "Sports"},
                new Genre() { Id = 5 ,Genre_Name = "Simulators"});

            modelBuilder.Entity<Publisher>()
                .HasData(new Publisher() { Id = 1, Publisher_Name = "EA Sports" },
                new Publisher() { Id = 2, Publisher_Name = "CD Projekt Red" },
                new Publisher() { Id = 3, Publisher_Name = "Blizzard" },
                new Publisher() { Id = 4, Publisher_Name = "GIANTS Software" }
                );

            modelBuilder.Entity<Game>()
                .HasData(new Game() {Id = 1 , GenreId = 1, Game_Name = "The Witcher", PublisherId = 2,
                Description = "\"The Witcher\" is an action role-playing game developed by CD Projekt Red, based on the book series by Andrzej Sapkowski. Set in a richly detailed, medieval fantasy world, players assume the role of Geralt of Rivia, a skilled monster hunter known as a Witcher. The game is renowned for its mature narrative, complex characters, and moral ambiguity, offering players a deeply immersive experience. In \"The Witcher,\" Geralt navigates through a world filled with political intrigue, supernatural threats, and moral dilemmas. Players make choices that influence the story and its outcome, engaging in combat with a variety of weapons and magical abilities. The game's open-world design allows for extensive exploration, with numerous side quests and activities to pursue alongside the main storyline"
                },
                new Game() { Id = 2 ,GenreId = 2, PublisherId = 3 , Game_Name = "Warcraft", Description = "\"Warcraft\" is a high-fantasy, real-time strategy game series developed and published by Blizzard Entertainment. Set in the expansive and lore-rich world of Azeroth, the game focuses on the epic conflict between various factions, primarily the Alliance and the Horde, as well as other races and factions with their own agendas." },
                new Game() { Id = 3 ,GenreId = 3, PublisherId = 3 , Game_Name = "Call of Duty", Description = "\"Call of Duty\" is a highly popular first-person shooter (FPS) video game series developed and published by Activision. Initially set in World War II, the franchise has since expanded to cover various historical periods, modern-day conflicts, and futuristic settings. Known for its intense gameplay, cinematic storytelling, and competitive multiplayer modes, \"Call of Duty\" has become one of the best-selling game franchises of all time." },
                new Game() { Id = 4 ,GenreId = 4, PublisherId = 1 , Game_Name = "Fifa", Description = "\"FIFA\" is a long-standing and immensely popular series of football (soccer) simulation video games developed and published by Electronic Arts (EA) under the EA Sports label. Known for its realistic gameplay, extensive licensing, and comprehensive game modes, \"FIFA\" has become the go-to title for football fans around the world." },
                new Game() { Id = 5 ,GenreId = 5, PublisherId = 4 , Game_Name = "Farming Simulator", Description = "\"Farming Simulator\" is a series of simulation video games developed by Giants Software. It offers players an immersive and detailed experience of managing a modern farm. The game emphasizes realistic farming activities, including cultivating crops, raising livestock, and managing machinery. It has gained a dedicated fanbase for its authentic representation of agricultural life and its comprehensive gameplay mechanics." });


            modelBuilder.Entity<Platform>()
                .HasData(new Platform() { Id = 1, Platform_Name = "Windows"},
                new Platform() { Id = 2, Platform_Name = "Play Station 5"},
                new Platform() { Id = 3, Platform_Name = "Play Station 4"},
                new Platform() { Id = 4, Platform_Name = "Play Station 3"},
                new Platform() { Id = 5, Platform_Name = "Play Station 2"},
                new Platform() { Id = 6, Platform_Name = "Xbox360"},
                new Platform() { Id = 7, Platform_Name = "Xbox One"},
                new Platform() { Id = 8, Platform_Name = "Xbox Series X"},
                new Platform() { Id = 9, Platform_Name = "Android" }
                );

            /*modelBuilder.Entity<Game_Publisher>()
                .HasData(new Game_Publisher() { Id = 1, GameId = 1, PublisherId =  2},
                new Game_Publisher() { Id = 2, GameId = 2, PublisherId = 3},
                new Game_Publisher() { Id = 3, GameId = 3, PublisherId = 3},
                new Game_Publisher() { Id = 4, GameId = 4, PublisherId = 1},
                new Game_Publisher() { Id = 5, GameId = 5, PublisherId = 4 }
                );*/

            modelBuilder.Entity<Region>()
                .HasData(new Region() { Id = 1, Region_Name = "Europa"},
                new Region() { Id = 2, Region_Name = "North America"},
                new Region() { Id = 3, Region_Name = "Asia"},
                new Region() { Id = 4, Region_Name = "Other" }
                );

            modelBuilder.Entity<Game_Platform>()
                .HasData(new Game_Platform() { Id = 1, GameId = 1, PlatformId = 1, ReleaseYear = 2015},
                new Game_Platform() { Id = 2, GameId = 1, PlatformId = 3, ReleaseYear = 2015 },
                new Game_Platform() { Id = 3, GameId = 1, PlatformId = 7, ReleaseYear = 2015 },
                new Game_Platform() { Id = 4, GameId = 1, PlatformId = 2, ReleaseYear = 2023 },
                new Game_Platform() { Id = 5, GameId = 1, PlatformId = 8, ReleaseYear = 2023 },
                new Game_Platform() { Id = 6, GameId = 5, PlatformId = 1, ReleaseYear = 2020 },
                new Game_Platform() { Id = 7, GameId = 5, PlatformId = 9, ReleaseYear = 2021 },
                new Game_Platform() { Id = 8, GameId = 2, PlatformId = 1, ReleaseYear = 2000 },
                new Game_Platform() { Id = 9, GameId = 2, PlatformId = 5, ReleaseYear = 2005 },
                new Game_Platform() { Id = 10, GameId = 3, PlatformId = 1, ReleaseYear = 2012 },
                new Game_Platform() { Id = 11, GameId = 3, PlatformId = 4, ReleaseYear = 2013 },
                new Game_Platform() { Id = 12, GameId = 3, PlatformId = 6, ReleaseYear = 2013 },
                new Game_Platform() { Id = 13, GameId = 4, PlatformId = 8, ReleaseYear = 2023 },
                new Game_Platform() { Id = 14, GameId = 4, PlatformId = 2, ReleaseYear = 2023 }
                );


            modelBuilder.Entity<Region_Sales>()
                .HasData(new Region_Sales() { RegionId = 1, Game_PlatformId = 1, Num_Sales = 90},
                new Region_Sales() { RegionId = 1, Game_PlatformId = 2, Num_Sales = 30},
                new Region_Sales() { RegionId = 2, Game_PlatformId = 2, Num_Sales = 40},
                new Region_Sales() { RegionId = 2, Game_PlatformId = 8, Num_Sales = 60 },
                new Region_Sales() { RegionId = 3, Game_PlatformId = 8, Num_Sales = 65 },
                new Region_Sales() { RegionId = 3, Game_PlatformId = 2, Num_Sales = 65 },
                new Region_Sales() { RegionId = 3, Game_PlatformId = 3, Num_Sales = 200 },
                new Region_Sales() { RegionId = 3, Game_PlatformId = 7, Num_Sales = 220 },
                new Region_Sales() { RegionId = 4, Game_PlatformId = 1, Num_Sales = 50 }
                );

            ///data for user_roles

            modelBuilder.Entity<Role>()
                .HasData(new Role() { Id = 1, RoleName = "Administrator"},
                new Role() { Id = 2, RoleName = "User"}
                );

            modelBuilder.Entity<User>()
                .HasData(new User() { Id = 1, Login = "User0", Password = "password123!"},
                    new User() { Id = 2, Login = "User1", Password = "password321!"}
                );

            modelBuilder.Entity<User_Role>()
                .HasData(new User_Role() { Id = 1, UserId = 1, RoleId = 1 },
                new User_Role() { Id = 2, UserId = 1, RoleId = 2},
                new User_Role() { Id = 3, UserId = 2, RoleId = 2 }
                );


            string roleId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>()
                .HasData(new IdentityRole()
                {
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    Id = roleId,
                    ConcurrencyStamp = roleId
                });

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>()
                .HasData(new IdentityUser
                {
                    Id = "1",
                    UserName = "User0",
                    NormalizedUserName = "USER0",
                    PasswordHash = hasher.HashPassword(null, "password123!")
                },
                new IdentityUser
                {
                    Id = "2",
                    UserName = "User1",
                    NormalizedUserName = "USER1",
                    PasswordHash = hasher.HashPassword(null, "password321!")
                });

            modelBuilder.Entity<IdentityUserRole<string>>()
                    .HasData(new IdentityUserRole<string>
                    {
                        RoleId = roleId,
                        UserId = "1"
                    });
        }
    }
}
