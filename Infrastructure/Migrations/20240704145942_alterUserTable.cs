using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class alterUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e173104e-c668-4812-b86d-d8bbd9b228bd", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e173104e-c668-4812-b86d-d8bbd9b228bd");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b635957a-d57e-44ec-8608-10000d09727d", "b635957a-d57e-44ec-8608-10000d09727d", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "69e860e6-6559-40a1-b698-3af63979a06a", "AQAAAAIAAYagAAAAEBiaKTwaOQis6kAS2DfzLcvdotc4bZA4Qy22fX3nptAyGv+omy7FGLAgvFSZNJRJEw==", "8d786ff4-4915-4415-96fa-8fa58c4e77f0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7d5a78e2-2190-4e21-8255-187fefaf2de4", "User1@onet.pl", true, "USER1@ONET.PL", "AQAAAAIAAYagAAAAEBpZ4Xq6t6XInUVus4oKPxjpExPtLtwGKjJ78k8m8s5K9lZRRWquFpRcYJNJlz2PhA==", "fc841a92-a1a1-4a27-9d57-92030cb5ac75" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "User0@onet.pl");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "User1@onet.pl");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b635957a-d57e-44ec-8608-10000d09727d", "1" },
                    { "b635957a-d57e-44ec-8608-10000d09727d", "2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b635957a-d57e-44ec-8608-10000d09727d", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b635957a-d57e-44ec-8608-10000d09727d", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b635957a-d57e-44ec-8608-10000d09727d");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e173104e-c668-4812-b86d-d8bbd9b228bd", "e173104e-c668-4812-b86d-d8bbd9b228bd", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f91bae9c-7eb8-4844-98e8-656e87271c26", "AQAAAAIAAYagAAAAEMJV1dWnCFxq/+aibP/9i1c/9Bwi55C3EB8d8fNK8sJvr9jWI6AQRSeO0ouqkRllfw==", "2a278a07-2654-4b0f-bcbf-ddc42f966f7b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "Email", "EmailConfirmed", "NormalizedEmail", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8960c172-c97e-4dcc-b424-588aba52f602", null, false, null, "AQAAAAIAAYagAAAAEIBydFSvqSi54k6WG+XHq+ajK1KHPHoIjLPssTc5EQoBu81OlaTh0bGPwN04+bMKjw==", "d22ad036-ba91-40df-ace8-0b950c938673" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e173104e-c668-4812-b86d-d8bbd9b228bd", "1" });
        }
    }
}
