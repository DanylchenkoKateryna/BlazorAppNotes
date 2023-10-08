using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppNotes.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateTime2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Notes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Utc).AddTicks(3266));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Utc).AddTicks(3322));

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Utc).AddTicks(3324));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Notes");
        }
    }
}
