using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class moreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Platform_Name" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "Play Station 5" },
                    { 3, "Play Station 4" },
                    { 4, "Play Station 3" },
                    { 5, "Play Station 2" },
                    { 6, "Xbox360" },
                    { 7, "Xbox One" },
                    { 8, "Xbox Series X" },
                    { 9, "Android" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Publisher_Name" },
                values: new object[,]
                {
                    { 1, "EA Sports" },
                    { 2, "CD Projekt Red" },
                    { 3, "Blizzard" },
                    { 4, "GIANTS Software" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Region_Name" },
                values: new object[,]
                {
                    { 1, "Europa" },
                    { 2, "North America" },
                    { 3, "Asia" },
                    { 4, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Game_Publishers",
                columns: new[] { "Id", "GameId", "PublisherId" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 2, 3 },
                    { 3, 3, 3 },
                    { 4, 4, 1 },
                    { 5, 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Game_Platforms",
                columns: new[] { "Id", "Game_PublisherId", "PlatformId", "ReleaseYear" },
                values: new object[,]
                {
                    { 1, 1, 1, 2015 },
                    { 2, 1, 3, 2015 },
                    { 3, 1, 7, 2015 },
                    { 4, 1, 2, 2023 },
                    { 5, 1, 8, 2023 },
                    { 6, 5, 1, 2020 },
                    { 7, 5, 9, 2021 },
                    { 8, 2, 1, 2000 },
                    { 9, 2, 5, 2005 },
                    { 10, 3, 1, 2012 },
                    { 11, 3, 4, 2013 },
                    { 12, 3, 6, 2013 },
                    { 13, 4, 8, 2023 },
                    { 14, 4, 2, 2023 }
                });

            migrationBuilder.InsertData(
                table: "Region_Sales",
                columns: new[] { "Game_PlatformId", "RegionId", "Num_Sales" },
                values: new object[,]
                {
                    { 1, 1, 90 },
                    { 2, 1, 30 },
                    { 2, 2, 40 },
                    { 8, 2, 60 },
                    { 2, 3, 65 },
                    { 3, 3, 200 },
                    { 7, 3, 220 },
                    { 8, 3, 65 },
                    { 1, 4, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "Region_Sales",
                keyColumns: new[] { "Game_PlatformId", "RegionId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Game_Platforms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Game_Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Game_Publishers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Game_Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Game_Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Game_Publishers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
