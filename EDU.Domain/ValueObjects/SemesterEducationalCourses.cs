using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class SemesterEducationalCourses
    {
        public int Id { get; set; }
        public Semester Semester { get; set; }
        public EducationalCourse EducationalCourse { get; set; }
    }
}
