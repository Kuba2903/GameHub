using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Games",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "\"The Witcher\" is an action role-playing game developed by CD Projekt Red, based on the book series by Andrzej Sapkowski. Set in a richly detailed, medieval fantasy world, players assume the role of Geralt of Rivia, a skilled monster hunter known as a Witcher. The game is renowned for its mature narrative, complex characters, and moral ambiguity, offering players a deeply immersive experience. In \"The Witcher,\" Geralt navigates through a world filled with political intrigue, supernatural threats, and moral dilemmas. Players make choices that influence the story and its outcome, engaging in combat with a variety of weapons and magical abilities. The game's open-world design allows for extensive exploration, with numerous side quests and activities to pursue alongside the main storyline");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "\"Warcraft\" is a high-fantasy, real-time strategy game series developed and published by Blizzard Entertainment. Set in the expansive and lore-rich world of Azeroth, the game focuses on the epic conflict between various factions, primarily the Alliance and the Horde, as well as other races and factions with their own agendas.");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "\"Call of Duty\" is a highly popular first-person shooter (FPS) video game series developed and published by Activision. Initially set in World War II, the franchise has since expanded to cover various historical periods, modern-day conflicts, and futuristic settings. Known for its intense gameplay, cinematic storytelling, and competitive multiplayer modes, \"Call of Duty\" has become one of the best-selling game franchises of all time.");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "\"FIFA\" is a long-standing and immensely popular series of football (soccer) simulation video games developed and published by Electronic Arts (EA) under the EA Sports label. Known for its realistic gameplay, extensive licensing, and comprehensive game modes, \"FIFA\" has become the go-to title for football fans around the world.");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "\"Farming Simulator\" is a series of simulation video games developed by Giants Software. It offers players an immersive and detailed experience of managing a modern farm. The game emphasizes realistic farming activities, including cultivating crops, raising livestock, and managing machinery. It has gained a dedicated fanbase for its authentic representation of agricultural life and its comprehensive gameplay mechanics.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Games");
        }
    }
}
