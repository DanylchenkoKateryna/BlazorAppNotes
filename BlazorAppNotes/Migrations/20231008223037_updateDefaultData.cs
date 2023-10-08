using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlazorAppNotes.Migrations
{
    /// <inheritdoc />
    public partial class updateDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate", "Title" },
                values: new object[] { "Content 1", new DateTime(2023, 10, 8, 22, 30, 37, 567, DateTimeKind.Utc).AddTicks(6009), "Title 1" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate", "Title" },
                values: new object[] { "Content 2", new DateTime(2023, 10, 8, 22, 30, 37, 567, DateTimeKind.Utc).AddTicks(6012), "Title 2" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                columns: new[] { "Content", "CreatedDate", "Title" },
                values: new object[] { "Content 3", new DateTime(2023, 10, 8, 22, 30, 37, 567, DateTimeKind.Utc).AddTicks(6013), "Title 3" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "Content", "CreatedDate", "Title" },
                values: new object[,]
                {
                    { 4, "Content 4", new DateTime(2023, 10, 8, 22, 30, 37, 567, DateTimeKind.Utc).AddTicks(6015), "Title 4" },
                    { 5, "Content 5", new DateTime(2023, 10, 8, 22, 30, 37, 567, DateTimeKind.Utc).AddTicks(6016), "Title 5" },
                    { 6, "Content 6", new DateTime(2023, 10, 8, 22, 30, 37, 567, DateTimeKind.Utc).AddTicks(6018), "Title 6" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 1,
                columns: new[] { "Content", "CreatedDate", "Title" },
                values: new object[] { "Hellooooo", new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Local).AddTicks(3266), "Hi" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 2,
                columns: new[] { "Content", "CreatedDate", "Title" },
                values: new object[] { "Kateryna", new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Local).AddTicks(3322), "Kate" });

            migrationBuilder.UpdateData(
                table: "Notes",
                keyColumn: "NoteId",
                keyValue: 3,
                columns: new[] { "Content", "CreatedDate", "Title" },
                values: new object[] { "abcdefg", new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Local).AddTicks(3324), "abc" });
        }
    }
}
