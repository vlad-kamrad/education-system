using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class FacultyDepartments
    {
        public int Id { get; set; }
        public Faculty Faculty { get; set; }
        public Department Department { get; set; }
    }
}
