using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DabHandIn2.Models
{
    public class HelpRequestContext : DbContext
    {

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public HelpRequestContext()
        {
        }

        public HelpRequestContext(DbContextOptions<HelpRequestContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
        } 

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Exercise>().HasKey(e => new { e.Lecture, e.Number }); //Sets two primary keys for Exercise table

            mb.Entity<Student>().HasKey(s => new { s.auId });

            mb.Entity<Teacher>().HasKey(t => new { t.auId });

            //Configuring N-N relationship for StudentCourse shadowtable
            mb.Entity<StudentCourse>().HasKey(sc => new { sc.auId, sc.CourseId });
            mb.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.auId);

            mb.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            //Seeding Data
            mb.Entity<Course>().HasData(
                new Course { CourseId = 1, Name = "Databaser" },
                new Course { CourseId = 2, Name = "GUI" }
                );
            mb.Entity<Teacher>().HasData(
                new Teacher{ Name = "Henrik Kirk", auId = 1, CourseId = 1},
                new Teacher{ Name = "Poul Ejnar",auId = 2, CourseId = 2 }
                );
            mb.Entity<Student>().HasData(
                new Student { Name = "Nikolaj AGRI", auId = 1, Email = "Agri@Agri.com" },
                new Student { Name = "Fredeirk", auId = 2, Email = "Rosendal@Rosendal.com" }
                );
            mb.Entity<Assignment>().HasData(
                new Assignment { Name = "Dab HandIn #2", Id = 1, CourseId = 1, StudentauId = 1},
                new Assignment { Name = "GUI for coffee shop", Id = 2, CourseId = 2, StudentauId = 2}
                );
            mb.Entity<Exercise>().HasData(
                new Exercise { Lecture = "Seeding Data in EF Core", CourseId = 1, Number = 56, StudentauId = 1}
                );
            mb.Entity<StudentCourse>().HasData(
                new StudentCourse { CourseId = 1, auId = 1, Active = true, Semester = 4},
                new StudentCourse { CourseId = 1, auId = 2, Active = true, Semester = 4},
                new StudentCourse { CourseId = 2, auId = 1, Active = true, Semester = 4},
                new StudentCourse { CourseId = 2, auId = 2, Active = true, Semester = 4}
                );
            
            


        }
    }
}
