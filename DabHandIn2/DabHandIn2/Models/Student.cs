﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DabHandIn2.Models
{
    public class Student
    {
        public int auId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<StudentCourse> StudentCourses { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
