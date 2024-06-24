using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class databaseChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Platforms_Game_Publishers_Game_PublisherId",
                table: "Game_Platforms");

            migrationBuilder.DropTable(
                name: "Game_Publishers");

            migrationBuilder.RenameColumn(
                name: "Game_PublisherId",
                table: "Game_Platforms",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_Platforms_Game_PublisherId",
                table: "Game_Platforms",
                newName: "IX_Game_Platforms_GameId");

            migrationBuilder.AddColumn<int>(
                name: "PublisherId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublisherId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublisherId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublisherId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublisherId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "PublisherId",
                value: 4);

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Platforms_Games_GameId",
                table: "Game_Platforms",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Platforms_Games_GameId",
                table: "Game_Platforms");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publishers_PublisherId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_PublisherId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PublisherId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Game_Platforms",
                newName: "Game_PublisherId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_Platforms_GameId",
                table: "Game_Platforms",
                newName: "IX_Game_Platforms_Game_PublisherId");

            migrationBuilder.CreateTable(
                name: "Game_Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game_Publishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Publishers_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Publishers_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Game_Publishers_GameId",
                table: "Game_Publishers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_Publishers_PublisherId",
                table: "Game_Publishers",
                column: "PublisherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Platforms_Game_Publishers_Game_PublisherId",
                table: "Game_Platforms",
                column: "Game_PublisherId",
                principalTable: "Game_Publishers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
