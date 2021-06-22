namespace EDU.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Head { get; set; }
    }
}
