﻿// <auto-generated />
using System;
using DabHandIn2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DabHandIn2.Migrations
{
    [DbContext(typeof(HelpRequestContext))]
    partial class HelpRequestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DabHandIn2.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherauId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TeacherauId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("DabHandIn2.Models.AssignmentExercise", b =>
                {
                    b.Property<string>("ExerciseLecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ExerciseNumber")
                        .HasColumnType("int");

                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.HasKey("ExerciseLecture", "ExerciseNumber", "AssignmentId");

                    b.HasIndex("AssignmentId");

                    b.ToTable("AssignmentExercises");
                });

            modelBuilder.Entity("DabHandIn2.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("DabHandIn2.Models.Exercise", b =>
                {
                    b.Property<string>("Lecture")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Help_Where")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StudentauId")
                        .HasColumnType("int");

                    b.Property<int?>("TeacherauId")
                        .HasColumnType("int");

                    b.HasKey("Lecture", "Number");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentauId");

                    b.HasIndex("TeacherauId");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("DabHandIn2.Models.Student", b =>
                {
                    b.Property<int>("auId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("auId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DabHandIn2.Models.StudentAssignment", b =>
                {
                    b.Property<int>("AssignmentId")
                        .HasColumnType("int");

                    b.Property<int>("auId")
                        .HasColumnType("int");

                    b.HasKey("AssignmentId", "auId");

                    b.HasIndex("auId");

                    b.ToTable("StudentAssignments");
                });

            modelBuilder.Entity("DabHandIn2.Models.StudentCourse", b =>
                {
                    b.Property<int>("auId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("auId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("DabHandIn2.Models.Teacher", b =>
                {
                    b.Property<int>("auId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("auId");

                    b.HasIndex("CourseId");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("DabHandIn2.Models.Assignment", b =>
                {
                    b.HasOne("DabHandIn2.Models.Course", null)
                        .WithMany("Assignments")
                        .HasForeignKey("CourseId");

                    b.HasOne("DabHandIn2.Models.Teacher", null)
                        .WithMany("Assignments")
                        .HasForeignKey("TeacherauId");
                });

            modelBuilder.Entity("DabHandIn2.Models.AssignmentExercise", b =>
                {
                    b.HasOne("DabHandIn2.Models.Assignment", "Assignment")
                        .WithMany("AssignmentExercises")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabHandIn2.Models.Exercise", "Exercise")
                        .WithMany("AssignmentExercises")
                        .HasForeignKey("ExerciseLecture", "ExerciseNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DabHandIn2.Models.Exercise", b =>
                {
                    b.HasOne("DabHandIn2.Models.Course", null)
                        .WithMany("Exercises")
                        .HasForeignKey("CourseId");

                    b.HasOne("DabHandIn2.Models.Student", null)
                        .WithMany("Exercises")
                        .HasForeignKey("StudentauId");

                    b.HasOne("DabHandIn2.Models.Teacher", null)
                        .WithMany("Exercises")
                        .HasForeignKey("TeacherauId");
                });

            modelBuilder.Entity("DabHandIn2.Models.StudentAssignment", b =>
                {
                    b.HasOne("DabHandIn2.Models.Assignment", "Assignment")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabHandIn2.Models.Student", "Student")
                        .WithMany("StudentAssignments")
                        .HasForeignKey("auId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DabHandIn2.Models.StudentCourse", b =>
                {
                    b.HasOne("DabHandIn2.Models.Course", "Course")
                        .WithMany("StudentCourses")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DabHandIn2.Models.Student", "Student")
                        .WithMany("StudentCourses")
                        .HasForeignKey("auId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DabHandIn2.Models.Teacher", b =>
                {
                    b.HasOne("DabHandIn2.Models.Course", "Course")
                        .WithMany("Teachers")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
