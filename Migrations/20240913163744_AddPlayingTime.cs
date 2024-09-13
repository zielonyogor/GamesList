using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesList.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayingTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PlayingSinceTime",
                table: "Games",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUri", "PlayingSinceTime", "Rating", "ReleaseTime" },
                values: new object[] { "Step into vast magical world of Adventure", "https://variety.com/wp-content/uploads/2022/09/Genshin-Impact-Anime-Series-Concept.png", new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, new DateTime(2020, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayingSinceTime",
                table: "Games");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "ImageUri", "Rating", "ReleaseTime" },
                values: new object[] { "Step into vast world", "meow", 1, new DateTime(2024, 9, 11, 23, 15, 54, 159, DateTimeKind.Local).AddTicks(949) });
        }
    }
}
