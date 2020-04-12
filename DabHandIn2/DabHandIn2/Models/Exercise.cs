using System.Collections.Generic;


namespace DabHandIn2.Models
{
    public class Exercise
    {
        public string Lecture { get; set; }
        public int Number { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentauId { get; set; }
    }
}