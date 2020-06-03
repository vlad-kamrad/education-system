using EDU.Domain.Entities;

namespace EDU.WebApi.Requests
{
    public class CreateGroupRequest
    {
        public string Title { get; set; }
        public User Curator { get; set; }
        public User HeadMan { get; set; }
    }

    public class ChangeStudentRequest
    {
        public int GroupId { get; set; }
        public int StudentId { get; set; }
    }
}
