using EDU.Domain.Entities;
using System;

namespace EDU.WebApi.Requests
{
    public class CreateEducationCourseRequest
    {
        public User Teacher { get; set; }
        public string Description { get; set; }
    }

    public class CreateSemesterRequest
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
