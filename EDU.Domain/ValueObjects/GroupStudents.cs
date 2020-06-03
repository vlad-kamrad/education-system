using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class GroupStudents
    {
        public int Id { get; set; }
        public Group Group { get; set; }
        public User Student { get; set; }
    }
}
