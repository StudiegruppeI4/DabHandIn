using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DabHandIn2.Models
{
    public class HelpRequestContext : DbContext
    {

        DbSet<Teacher> Teachers { get; set; }
        DbSet<Exercise> Exercises { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Assignment> Assignments { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<AssignmentExercise> AssignmentExercises { get; set; }
        DbSet<StudentAssignment> StudentAssignments { get; set; }
        DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string connectionString = "@Server = (localdb)\\mssqllocaldb; Database = EFProviders.InMemory; Trusted_Connection = True; ConnectRetryCount = 0";
            options.UseSqlServer(connectionString);
        } 

        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.Entity<Exercise>().HasKey(e => new { e.Lecture, e.Number }); //Sets two primary keys for Exercise table

            mb.Entity<Student>().HasKey(s => new { s.auId });

            mb.Entity<Teacher>().HasKey(t => new { t.auId });

            //Configuring N-N relationship for AssignmentExercise shadowtable
            mb.Entity<AssignmentExercise>().HasKey(ae => new { ae.ExerciseLecture, ae.ExerciseNumber, ae.AssignmentId });
            mb.Entity<AssignmentExercise>()
                .HasOne(ae => ae.Exercise)
                .WithMany(e => e.AssignmentExercises)
                .HasForeignKey(ae => new { ae.ExerciseLecture, ae.ExerciseNumber });

            mb.Entity<AssignmentExercise>()
                .HasOne(ae => ae.Assignment)
                .WithMany(a => a.AssignmentExercises)
                .HasForeignKey(ae => ae.AssignmentId);

            //Cofiguring N-N relationship for StudentCourse shadowtable
            mb.Entity<StudentCourse>().HasKey(sc => new { sc.auId, sc.CourseId });
            mb.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.auId);

            mb.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            //Configuring N-N relationship for StudentAssignment shadowtable
            mb.Entity<StudentAssignment>().HasKey(sa => new { sa.AssignmentId, sa.auId });
            mb.Entity<StudentAssignment>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentAssignments)
                .HasForeignKey(sa => sa.auId);

            mb.Entity<StudentAssignment>()
                .HasOne(sa => sa.Assignment)
                .WithMany(a => a.StudentAssignments)
                .HasForeignKey(sa => sa.AssignmentId);
        }
    }
}
