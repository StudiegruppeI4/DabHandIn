using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DabHandIn2.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }



}
