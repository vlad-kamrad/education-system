using EDU.Domain.Entities;
using System.Collections.Generic;

namespace EDU.Application.Boundaries.GetUser.GetAllDepartments
{
    public class GetAllDepartmentsOutput
    {
        public IList<Domain.Entities.Department> Departments;

        public GetAllDepartmentsOutput(IList<Domain.Entities.Department> departments) => Departments = departments;
    }
}
