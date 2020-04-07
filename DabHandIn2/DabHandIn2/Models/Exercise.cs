using System.Collections.Generic;


namespace DabHandIn2.Models
{
    public class Exercise
    {
        public string Lecture { get; set; }
        public int Number { get; set; }
        public string Help_Where { get; set; }
        public ICollection<AssignmentExercise> AssignmentExercises { get; set; }
    }
}