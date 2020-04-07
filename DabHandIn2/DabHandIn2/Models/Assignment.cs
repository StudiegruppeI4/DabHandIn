using System.Collections.Generic;
namespace DabHandIn2.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public ICollection<AssignmentExercise> AssignmentExercises { get; set; }
        public ICollection<StudentAssignment> StudentAssignments { get; set; }
    }
}