using EDU.Domain.Entities;

namespace EDU.Domain.ValueObjects
{
    public class DepartamentDisciplines
    {
        public int Id { get; set; }
        public Department Department { get; set; }
        public Discipline Discipline { get; set; }
    }
}
