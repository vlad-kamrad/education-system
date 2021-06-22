using EDU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDU.WebApi.Requests
{
    public class CreateDepartmentRequest
    {
        public string Name { get; set; }
        public int HeadId { get; set; }
    }

    public class CreateDisciplineRequest
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class CreateFacultyRequest
    {
        public string Title { get; set; }
        public User Head { get; set; }
        public User Subhead { get; set; }
    }
}
