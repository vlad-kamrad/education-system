namespace EDU.Domain.Entities
{
    public class Exam
    {
        public int Id { get; set; }
        public User Examiner { get; set; }
        public Discipline Discipline { get; set; }
        public Group Group { get; set; }
    }
}
