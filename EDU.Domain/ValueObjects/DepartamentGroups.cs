using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class DepartamentGroups
    {
        public int Id { get; set; }
        public Department Department { get; set; }
        public Group Group { get; set; }
    }
}
