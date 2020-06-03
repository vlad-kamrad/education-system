using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class EducationalCourseGroups
    {
        public int Id { get; set; }
        public EducationalCourse EducationalCourse { get; set; }
        public Group Group { get; set; }
    }
}
