﻿// <auto-generated />
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.Entities.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Game_Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Game_Name = "The Witcher",
                            GenreId = 1
                        },
                        new
                        {
                            Id = 2,
                            Game_Name = "Warcraft",
                            GenreId = 2
                        },
                        new
                        {
                            Id = 3,
                            Game_Name = "Call of Duty",
                            GenreId = 3
                        },
                        new
                        {
                            Id = 4,
                            Game_Name = "Fifa",
                            GenreId = 4
                        },
                        new
                        {
                            Id = 5,
                            Game_Name = "Farming Simulator",
                            GenreId = 5
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Game_Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Game_PublisherId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformId")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Game_PublisherId");

                    b.HasIndex("PlatformId");

                    b.ToTable("Game_Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Game_PublisherId = 1,
                            PlatformId = 1,
                            ReleaseYear = 2015
                        },
                        new
                        {
                            Id = 2,
                            Game_PublisherId = 1,
                            PlatformId = 3,
                            ReleaseYear = 2015
                        },
                        new
                        {
                            Id = 3,
                            Game_PublisherId = 1,
                            PlatformId = 7,
                            ReleaseYear = 2015
                        },
                        new
                        {
                            Id = 4,
                            Game_PublisherId = 1,
                            PlatformId = 2,
                            ReleaseYear = 2023
                        },
                        new
                        {
                            Id = 5,
                            Game_PublisherId = 1,
                            PlatformId = 8,
                            ReleaseYear = 2023
                        },
                        new
                        {
                            Id = 6,
                            Game_PublisherId = 5,
                            PlatformId = 1,
                            ReleaseYear = 2020
                        },
                        new
                        {
                            Id = 7,
                            Game_PublisherId = 5,
                            PlatformId = 9,
                            ReleaseYear = 2021
                        },
                        new
                        {
                            Id = 8,
                            Game_PublisherId = 2,
                            PlatformId = 1,
                            ReleaseYear = 2000
                        },
                        new
                        {
                            Id = 9,
                            Game_PublisherId = 2,
                            PlatformId = 5,
                            ReleaseYear = 2005
                        },
                        new
                        {
                            Id = 10,
                            Game_PublisherId = 3,
                            PlatformId = 1,
                            ReleaseYear = 2012
                        },
                        new
                        {
                            Id = 11,
                            Game_PublisherId = 3,
                            PlatformId = 4,
                            ReleaseYear = 2013
                        },
                        new
                        {
                            Id = 12,
                            Game_PublisherId = 3,
                            PlatformId = 6,
                            ReleaseYear = 2013
                        },
                        new
                        {
                            Id = 13,
                            Game_PublisherId = 4,
                            PlatformId = 8,
                            ReleaseYear = 2023
                        },
                        new
                        {
                            Id = 14,
                            Game_PublisherId = 4,
                            PlatformId = 2,
                            ReleaseYear = 2023
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Game_Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<int>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Game_Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 1,
                            PublisherId = 2
                        },
                        new
                        {
                            Id = 2,
                            GameId = 2,
                            PublisherId = 3
                        },
                        new
                        {
                            Id = 3,
                            GameId = 3,
                            PublisherId = 3
                        },
                        new
                        {
                            Id = 4,
                            GameId = 4,
                            PublisherId = 1
                        },
                        new
                        {
                            Id = 5,
                            GameId = 5,
                            PublisherId = 4
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Genre_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genre_Name = "RPG"
                        },
                        new
                        {
                            Id = 2,
                            Genre_Name = "RTS"
                        },
                        new
                        {
                            Id = 3,
                            Genre_Name = "Shooters"
                        },
                        new
                        {
                            Id = 4,
                            Genre_Name = "Sports"
                        },
                        new
                        {
                            Id = 5,
                            Genre_Name = "Simulators"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Platform_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Platform_Name = "Windows"
                        },
                        new
                        {
                            Id = 2,
                            Platform_Name = "Play Station 5"
                        },
                        new
                        {
                            Id = 3,
                            Platform_Name = "Play Station 4"
                        },
                        new
                        {
                            Id = 4,
                            Platform_Name = "Play Station 3"
                        },
                        new
                        {
                            Id = 5,
                            Platform_Name = "Play Station 2"
                        },
                        new
                        {
                            Id = 6,
                            Platform_Name = "Xbox360"
                        },
                        new
                        {
                            Id = 7,
                            Platform_Name = "Xbox One"
                        },
                        new
                        {
                            Id = 8,
                            Platform_Name = "Xbox Series X"
                        },
                        new
                        {
                            Id = 9,
                            Platform_Name = "Android"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Publisher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Publisher_Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Publisher_Name = "EA Sports"
                        },
                        new
                        {
                            Id = 2,
                            Publisher_Name = "CD Projekt Red"
                        },
                        new
                        {
                            Id = 3,
                            Publisher_Name = "Blizzard"
                        },
                        new
                        {
                            Id = 4,
                            Publisher_Name = "GIANTS Software"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Region_Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Region_Name = "Europa"
                        },
                        new
                        {
                            Id = 2,
                            Region_Name = "North America"
                        },
                        new
                        {
                            Id = 3,
                            Region_Name = "Asia"
                        },
                        new
                        {
                            Id = 4,
                            Region_Name = "Other"
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Region_Sales", b =>
                {
                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<int>("Game_PlatformId")
                        .HasColumnType("int");

                    b.Property<int>("Num_Sales")
                        .HasColumnType("int");

                    b.HasKey("RegionId", "Game_PlatformId");

                    b.HasIndex("Game_PlatformId");

                    b.ToTable("Region_Sales");

                    b.HasData(
                        new
                        {
                            RegionId = 1,
                            Game_PlatformId = 1,
                            Num_Sales = 90
                        },
                        new
                        {
                            RegionId = 1,
                            Game_PlatformId = 2,
                            Num_Sales = 30
                        },
                        new
                        {
                            RegionId = 2,
                            Game_PlatformId = 2,
                            Num_Sales = 40
                        },
                        new
                        {
                            RegionId = 2,
                            Game_PlatformId = 8,
                            Num_Sales = 60
                        },
                        new
                        {
                            RegionId = 3,
                            Game_PlatformId = 8,
                            Num_Sales = 65
                        },
                        new
                        {
                            RegionId = 3,
                            Game_PlatformId = 2,
                            Num_Sales = 65
                        },
                        new
                        {
                            RegionId = 3,
                            Game_PlatformId = 3,
                            Num_Sales = 200
                        },
                        new
                        {
                            RegionId = 3,
                            Game_PlatformId = 7,
                            Num_Sales = 220
                        },
                        new
                        {
                            RegionId = 4,
                            Game_PlatformId = 1,
                            Num_Sales = 50
                        });
                });

            modelBuilder.Entity("Infrastructure.Entities.Game", b =>
                {
                    b.HasOne("Infrastructure.Entities.Genre", "Genre")
                        .WithMany("Games")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("Infrastructure.Entities.Game_Platform", b =>
                {
                    b.HasOne("Infrastructure.Entities.Game_Publisher", "Game_Publisher")
                        .WithMany("Game_Platforms")
                        .HasForeignKey("Game_PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Platform", "Platform")
                        .WithMany("Game_Platforms")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game_Publisher");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("Infrastructure.Entities.Game_Publisher", b =>
                {
                    b.HasOne("Infrastructure.Entities.Game", "Game")
                        .WithMany("Games_Publishers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Publisher", "Publisher")
                        .WithMany("Games_Publishers")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("Infrastructure.Entities.Region_Sales", b =>
                {
                    b.HasOne("Infrastructure.Entities.Game_Platform", "Game_Platform")
                        .WithMany("Region_Sales")
                        .HasForeignKey("Game_PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.Entities.Region", "Region")
                        .WithMany("Region_Sales")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game_Platform");

                    b.Navigation("Region");
                });

            modelBuilder.Entity("Infrastructure.Entities.Game", b =>
                {
                    b.Navigation("Games_Publishers");
                });

            modelBuilder.Entity("Infrastructure.Entities.Game_Platform", b =>
                {
                    b.Navigation("Region_Sales");
                });

            modelBuilder.Entity("Infrastructure.Entities.Game_Publisher", b =>
                {
                    b.Navigation("Game_Platforms");
                });

            modelBuilder.Entity("Infrastructure.Entities.Genre", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Infrastructure.Entities.Platform", b =>
                {
                    b.Navigation("Game_Platforms");
                });

            modelBuilder.Entity("Infrastructure.Entities.Publisher", b =>
                {
                    b.Navigation("Games_Publishers");
                });

            modelBuilder.Entity("Infrastructure.Entities.Region", b =>
                {
                    b.Navigation("Region_Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
