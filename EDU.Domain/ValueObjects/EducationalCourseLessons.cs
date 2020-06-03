using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class EducationalCourseLessons
    {
        public int Id { get; set; }
        public EducationalCourse EducationalCourse { get; set; }
        public Lesson Lesson { get; set; }
    }
}
