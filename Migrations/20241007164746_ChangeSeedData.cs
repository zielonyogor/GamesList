using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesList.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUri",
                value: "icon-diamond");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUri",
                value: "https://variety.com/wp-content/uploads/2022/09/Genshin-Impact-Anime-Series-Concept.png");
        }
    }
}
