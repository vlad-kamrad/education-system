namespace EDU.Domain.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public User Curator { get; set; }
        public User HeadMan { get; set; }
        public bool IsActive { get; set; }
    }
}
