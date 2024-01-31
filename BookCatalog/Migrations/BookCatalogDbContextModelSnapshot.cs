﻿// <auto-generated />
using System;
using BookCatalog.Entities.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookCatalog.Migrations
{
    [DbContext(typeof(BookCatalogDbContext))]
    partial class BookCatalogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookCatalog.Entities.Models.Book", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Description = "Japanese Manga",
                            PublishDateUtc = new DateTime(2024, 1, 31, 7, 10, 29, 201, DateTimeKind.Utc).AddTicks(9295),
                            Title = "One Piece"
                        },
                        new
                        {
                            Id = 2L,
                            Description = "Romance",
                            PublishDateUtc = new DateTime(2024, 1, 31, 7, 10, 29, 201, DateTimeKind.Utc).AddTicks(9298),
                            Title = "Titanic"
                        },
                        new
                        {
                            Id = 3L,
                            Description = "Cartoon",
                            PublishDateUtc = new DateTime(2024, 1, 31, 7, 10, 29, 201, DateTimeKind.Utc).AddTicks(9299),
                            Title = "Doraemon"
                        });
                });

            modelBuilder.Entity("BookCatalog.Entities.Models.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "History"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Adventure"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
