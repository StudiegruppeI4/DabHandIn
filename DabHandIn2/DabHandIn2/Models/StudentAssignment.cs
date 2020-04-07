namespace DabHandIn2.Models
{
    public class StudentAssignment
    {
        public string auId { get; set; }
        public Student Student { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}