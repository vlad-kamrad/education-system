using EDU.Domain.Entities;

namespace EDU.Application.Boundaries.Department
{
    public class UpdateDepartmentInput
    {
        public Domain.Entities.Department UpdatedDepartment { get; }

        public UpdateDepartmentInput(Domain.Entities.Department newDepartment) => UpdatedDepartment = newDepartment;
    }
}
