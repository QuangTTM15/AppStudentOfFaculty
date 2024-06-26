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
    [Migration("20240410071452_InnitDB")]
    partial class InnitDB
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
                            CreatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(525),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Administrator",
                            UpdatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(551)
                        },
                        new
                        {
                            Id = 2L,
                            CreatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1063),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Manager",
                            UpdatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1065)
                        },
                        new
                        {
                            Id = 3L,
                            CreatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1066),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Coordinator",
                            UpdatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1067)
                        },
                        new
                        {
                            Id = 4L,
                            CreatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1069),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Student",
                            UpdatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1069)
                        },
                        new
                        {
                            Id = 5L,
                            CreatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1071),
                            CreatedBy = 1L,
                            IsActive = true,
                            IsDelete = false,
                            Name = "Guest",
                            UpdatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1072)
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
                            CreatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 638, DateTimeKind.Local).AddTicks(4486),
                            CreatedBy = 0L,
                            Email = "admin@gmail.com",
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
                            CreatedAt = new DateTime(2024, 4, 10, 14, 14, 52, 640, DateTimeKind.Local).AddTicks(1422),
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
