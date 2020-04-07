namespace DabHandIn2.Models
{
    public class AssignmentExercise
    {
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
        public int ExerciseNumber { get; set; }
        public string ExerciseLecture { get; set; }
        public Exercise Exercise { get; set; }
    }
}