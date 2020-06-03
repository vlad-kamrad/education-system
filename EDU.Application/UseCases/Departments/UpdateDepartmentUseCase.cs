using EDU.Application.Boundaries.Department;
using EDU.Application.Boundaries.Department.UpdateDepartmentUseCase;
using EDU.Application.Boundaries.GetUser.UpdateDepartmentUseCase;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Departments
{
    public class UpdateDepartmentUseCase : IUpdateDepartmentUseCase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IUpdateDepartmentOutputPort outputPort;

        public UpdateDepartmentUseCase(IUpdateDepartmentOutputPort outputPort, IDepartmentRepository departmentRepository)
        {
            this.outputPort = outputPort;
            this.departmentRepository = departmentRepository;
        }

        public async Task Execute(UpdateDepartmentInput input)
        {
            if (input == null) { outputPort.WriteError(""); }
            if (await departmentRepository.GetDepartment(input.UpdatedDepartment.Id) == null) { outputPort.NotFound(""); }

            bool success = await departmentRepository.Update(input.UpdatedDepartment);
            outputPort.Standart(new UpdateDepartmentOutput(success));
        }
    }
}
