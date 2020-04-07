using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DabHandIn2.Models
{
    public class Teacher
    {
        public int auId { get; set; }
        public string Name { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
