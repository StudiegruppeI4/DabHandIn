using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DabHandIn2.Models
{
    //Shadowtable for N-N between students and courses
    public class StudentCourse
    {
        public string auId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public bool Active { get; set; }
        public int Semester { get; set; }
    }
}
