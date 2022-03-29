﻿// <auto-generated />
using System;
using AuthorizationMicroservice.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AuthorizationMicroservice.Db.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220214204028_AddUniqLoginIndex")]
    partial class AddUniqLoginIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AuthorizationMicroservice.Db.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cf34f038-c26f-4579-8fd9-1eaa66a6f727"),
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("a896256c-ce78-4010-b8be-335737cfc787"),
                            Name = "Guest"
                        });
                });

            modelBuilder.Entity("AuthorizationMicroservice.Db.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce06ee28-912b-4fa6-bd2c-9583aca76115"),
                            Login = "admin",
                            Password = "admin"
                        },
                        new
                        {
                            Id = new Guid("d2a10481-6fa2-45f0-bd42-5182d4fb24c3"),
                            Login = "guest",
                            Password = "guest"
                        });
                });

            modelBuilder.Entity("AuthorizationMicroservice.Db.Models.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ID");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0d2fd55f-e672-40e1-8d00-9c5b8a933458"),
                            RoleId = new Guid("cf34f038-c26f-4579-8fd9-1eaa66a6f727"),
                            UserId = new Guid("ce06ee28-912b-4fa6-bd2c-9583aca76115")
                        },
                        new
                        {
                            Id = new Guid("80455e73-a751-4a9d-9596-5c8f61b6a71b"),
                            RoleId = new Guid("a896256c-ce78-4010-b8be-335737cfc787"),
                            UserId = new Guid("d2a10481-6fa2-45f0-bd42-5182d4fb24c3")
                        });
                });

            modelBuilder.Entity("AuthorizationMicroservice.Db.Models.UserRole", b =>
                {
                    b.HasOne("AuthorizationMicroservice.Db.Models.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AuthorizationMicroservice.Db.Models.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AuthorizationMicroservice.Db.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("AuthorizationMicroservice.Db.Models.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
