﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_Management_API.Configurations;

#nullable disable

namespace Student_Management_API.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20231202140139_InitStudentDb")]
    partial class InitStudentDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Student_Management_API.Model.Grades.Grade", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("Student_Management_API.Model.Students.Student", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .IsUnicode(false)
                        .HasColumnType("varchar(36)")
                        .HasColumnName("Id");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Code");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("CreatedOn");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnType("datetime")
                        .HasColumnName("LastUpdatedOn");

                    b.Property<byte>("Major")
                        .HasColumnType("tinyint")
                        .HasColumnName("Major");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "b47e9365-2d42-4ede-911e-e41c377678f4",
                            Code = "STU001",
                            CreatedOn = new DateTime(2023, 12, 2, 21, 1, 38, 841, DateTimeKind.Local).AddTicks(4777),
                            Major = (byte)128,
                            Name = "Penh Polydet"
                        },
                        new
                        {
                            Id = "3341eddb-9ded-4ef3-a269-3a3e2ee516f6",
                            Code = "STU002",
                            CreatedOn = new DateTime(2023, 12, 2, 21, 1, 38, 841, DateTimeKind.Local).AddTicks(4798),
                            Major = (byte)1,
                            Name = "Penh Vireak"
                        },
                        new
                        {
                            Id = "f68c6e04-1168-4569-8a1c-259aea0f9f29",
                            Code = "STU003",
                            CreatedOn = new DateTime(2023, 12, 2, 21, 1, 38, 841, DateTimeKind.Local).AddTicks(4805),
                            Major = (byte)4,
                            Name = "Penh Veasna"
                        });
                });

            modelBuilder.Entity("Student_Management_API.Model.Grades.Grade", b =>
                {
                    b.HasOne("Student_Management_API.Model.Students.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Student_Management_API.Model.Students.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}