using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DabHandIn2.Models
{
    public class Student
    {
        public string auId { get; set; }
        public string Name { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
