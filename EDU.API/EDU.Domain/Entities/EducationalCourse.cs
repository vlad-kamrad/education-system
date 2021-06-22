namespace EDU.Domain.Entities
{
    public class EducationalCourse
    {
        public int Id { get; set; }
        public User Teacher { get; set; }
        public string Description { get; set; }
    }
}
