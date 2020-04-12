using System.Collections.Generic;
namespace DabHandIn2.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int StudentauId { get; set; }
    }
}