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
        }
    }
}
