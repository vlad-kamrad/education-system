using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class DepartmentSemesters
    {
        public int Id { get; set; }
        public Department Department { get; set; }
        public Semester Semester { get; set; }
    }
}
