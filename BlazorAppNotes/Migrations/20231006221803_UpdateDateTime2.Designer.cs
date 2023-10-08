﻿// <auto-generated />
using System;
using BlazorAppNotes.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlazorAppNotes.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20231006221803_UpdateDateTime2")]
    partial class UpdateDateTime2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BlazorAppNotes.Data.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("NoteId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Hellooooo",
                            CreatedDate = new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Local).AddTicks(3266),
                            Title = "Hi"
                        },
                        new
                        {
                            Id = 2,
                            Content = "Kateryna",
                            CreatedDate = new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Local).AddTicks(3322),
                            Title = "Kate"
                        },
                        new
                        {
                            Id = 3,
                            Content = "abcdefg",
                            CreatedDate = new DateTime(2023, 10, 7, 1, 18, 2, 895, DateTimeKind.Local).AddTicks(3324),
                            Title = "abc"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
