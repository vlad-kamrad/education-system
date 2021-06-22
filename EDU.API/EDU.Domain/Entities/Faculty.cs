namespace EDU.Domain.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User Head { get; set; }
        public User Subhead { get; set; }
    }
}
