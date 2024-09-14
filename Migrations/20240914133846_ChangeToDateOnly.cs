using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesList.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToDateOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PlayingSinceTime", "ReleaseTime" },
                values: new object[] { new DateOnly(2021, 3, 31), new DateOnly(2020, 9, 28) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PlayingSinceTime", "ReleaseTime" },
                values: new object[] { new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
