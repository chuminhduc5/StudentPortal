﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Data;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20241110091708_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.AcademicYear", b =>
                {
                    b.Property<int>("AcademicYearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AcademicYearId"));

                    b.Property<string>("YearRange")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AcademicYearId");

                    b.ToTable("AcademicYears");
                });

            modelBuilder.Entity("api.Models.Attendance", b =>
                {
                    b.Property<int>("AttendanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AttendanceId"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AttendanceId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("api.Models.Faculty", b =>
                {
                    b.Property<int>("FacultyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FacultyId"));

                    b.Property<string>("FacultyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FacultyId");

                    b.ToTable("Faculties");
                });

            modelBuilder.Entity("api.Models.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeId"));

                    b.Property<decimal>("Score")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("api.Models.GradeType", b =>
                {
                    b.Property<int>("GradeTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GradeTypeId"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GradeTypeId");

                    b.ToTable("GradeTypes");
                });

            modelBuilder.Entity("api.Models.Major", b =>
                {
                    b.Property<int>("MajorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MajorId"));

                    b.Property<string>("MajorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MajorId");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("api.Models.Semester", b =>
                {
                    b.Property<int>("SemesterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SemesterId"));

                    b.Property<string>("SemesterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SemesterId");

                    b.ToTable("Semesters");
                });

            modelBuilder.Entity("api.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("ContactAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("EducationSystem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EnrollmentYear")
                        .HasColumnType("int");

                    b.Property<string>("Ethnicity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentityCard")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MajorId")
                        .HasColumnType("int");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.HasIndex("MajorId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("api.Models.Subject", b =>
                {
                    b.Property<int>("SubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectId"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubjectId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("api.Models.Timetable", b =>
                {
                    b.Property<int>("TimetableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimetableId"));

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("TimetableId");

                    b.ToTable("Timetables");
                });

            modelBuilder.Entity("api.Models.Student", b =>
                {
                    b.HasOne("api.Models.Major", "Major")
                        .WithMany()
                        .HasForeignKey("MajorId");

                    b.Navigation("Major");
                });
#pragma warning restore 612, 618
        }
    }
}
