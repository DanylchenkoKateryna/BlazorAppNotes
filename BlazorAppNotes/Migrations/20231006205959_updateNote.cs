﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorAppNotes.Migrations
{
    /// <inheritdoc />
    public partial class updateNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Notes",
                newName: "NoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Notes",
                newName: "Id");
        }
    }
}
