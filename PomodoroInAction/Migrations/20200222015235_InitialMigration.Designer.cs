﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PomodoroInAction.Models;

namespace PomodoroInAction.Migrations
{
    [DbContext(typeof(PomodoroAppDbContext))]
    [Migration("20200222015235_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PomodoroInAction.Models.Board", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnName("sort_order")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("board");
                });

            modelBuilder.Entity("PomodoroInAction.Models.KanbanContainer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("BoardId")
                        .HasColumnName("board_id")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<int>("SortOrder")
                        .HasColumnName("sort_order")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BoardId");

                    b.ToTable("container");
                });

            modelBuilder.Entity("PomodoroInAction.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("text");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnName("display_name")
                        .HasColumnType("text");

                    b.Property<int>("KanbanContainerId")
                        .HasColumnName("container_id")
                        .HasColumnType("integer");

                    b.Property<int>("SortOrder")
                        .HasColumnName("sort_order")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("KanbanContainerId");

                    b.ToTable("ticket");
                });

            modelBuilder.Entity("PomodoroInAction.Models.KanbanContainer", b =>
                {
                    b.HasOne("PomodoroInAction.Models.Board", null)
                        .WithMany("Containers")
                        .HasForeignKey("BoardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PomodoroInAction.Models.Ticket", b =>
                {
                    b.HasOne("PomodoroInAction.Models.KanbanContainer", null)
                        .WithMany("Tickets")
                        .HasForeignKey("KanbanContainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}