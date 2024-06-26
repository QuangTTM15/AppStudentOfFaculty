﻿// <auto-generated />
using System;
using AppStudentOfFaculty.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AppStudentOfFaculty.Entity.Migrations
{
    [DbContext(typeof(HungHoangContext))]
    [Migration("20240412040648_addColumnFaculty")]
    partial class addColumnFaculty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AppStudentOfFaculty.Entity.Contribution.ContributionCommentEntities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ContributionId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("ContributionComment");
                });

            modelBuilder.Entity("AppStudentOfFaculty.Entity.Contribution.ContributionEntities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("TypeFile")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Contribution");
                });

            modelBuilder.Entity("AppStudentOfFaculty.Entity.Department.DepartmentEntities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("FacultyId")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("AppStudentOfFaculty.Entity.Faculty.FacultyEntities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<long>("CoordinatorId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Faculty");
                });

            modelBuilder.Entity("AppStudentOfFaculty.Entity.User.RoleEntities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(94),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Administrator",
                            UpdatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(120)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(641),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Manager",
                            UpdatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(643)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(644),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Coordinator",
                            UpdatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(645)
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(646),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Student",
                            UpdatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(647)
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(648),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Guest",
                            UpdatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(649)
                        });
                });

            modelBuilder.Entity("AppStudentOfFaculty.Entity.User.UserEntities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avartar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("FacultyId")
                        .HasColumnType("bigint");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSupperAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 880, DateTimeKind.Local).AddTicks(2567),
                            CreatedBy = 0L,
                            Email = "admin@gmail.com",
                            FacultyId = 0L,
                            FullName = "admin@gmail.com",
                            Gender = 0,
                            IsActive = true,
                            IsDelete = false,
                            IsSupperAdmin = true,
                            Level = 0,
                            Password = "123",
                            Phone = "099999999",
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("AppStudentOfFaculty.Entity.User.UserRoleEntities", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<long?>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedAt = new DateTime(2024, 4, 12, 11, 6, 47, 882, DateTimeKind.Local).AddTicks(975),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            RoleId = 1L,
                            UpdatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
