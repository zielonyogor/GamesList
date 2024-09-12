using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesList.Migrations
{
    /// <inheritdoc />
    public partial class TitleDefault : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseTime",
                value: new DateTime(2024, 9, 11, 23, 15, 54, 159, DateTimeKind.Local).AddTicks(949));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ReleaseTime",
                value: new DateTime(2024, 9, 11, 21, 52, 19, 195, DateTimeKind.Local).AddTicks(3593));
        }
    }
}
