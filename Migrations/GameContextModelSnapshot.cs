﻿// <auto-generated />
using System;
using GamesList.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamesList.Migrations
{
    [DbContext(typeof(GameContext))]
    partial class GameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("GamesList.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUri")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Rating")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ReleaseTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Step into vast world",
                            ImageUri = "meow",
                            Rating = 1,
                            ReleaseTime = new DateTime(2024, 9, 11, 23, 15, 54, 159, DateTimeKind.Local).AddTicks(949),
                            Title = "Genshin Impact"
                        });
                });

            modelBuilder.Entity("GamesList.Models.GameTags", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagId")
                        .HasColumnType("INTEGER");

                    b.HasKey("GameId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("GameTags");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            TagId = 1
                        },
                        new
                        {
                            GameId = 1,
                            TagId = 2
                        });
                });

            modelBuilder.Entity("GamesList.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "RPG"
                        },
                        new
                        {
                            Id = 2,
                            Name = "cozy"
                        });
                });

            modelBuilder.Entity("GamesList.Models.GameTags", b =>
                {
                    b.HasOne("GamesList.Models.Game", "Game")
                        .WithMany("GameTags")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesList.Models.Tag", "Tag")
                        .WithMany("GameTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("GamesList.Models.Game", b =>
                {
                    b.Navigation("GameTags");
                });

            modelBuilder.Entity("GamesList.Models.Tag", b =>
                {
                    b.Navigation("GameTags");
                });
#pragma warning restore 612, 618
        }
    }
}
