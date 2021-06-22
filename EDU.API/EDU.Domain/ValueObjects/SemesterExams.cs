using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class SemesterExams
    {
        public int Id { get; set; }
        public Semester Semester { get; set; }
        public Exam Exam { get; set; }
    }
}
