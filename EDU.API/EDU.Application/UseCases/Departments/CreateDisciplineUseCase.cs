using EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Departments
{
    public class CreateDisciplineUseCase : ICreateDisciplineUseCase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICreateDisciplineOutputPort outputPort;

        public CreateDisciplineUseCase(IDepartmentRepository departmentRepository, ICreateDisciplineOutputPort outputPort)
        {
            this.departmentRepository = departmentRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(CreateDisciplineInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }
            if (await departmentRepository.GetDepartment(input.DepartmentId) == null) { outputPort.NotFound(""); }

            var disciplineId = await departmentRepository.CreateDiscipline(input.DepartmentId, input.Name, input.Description);
            outputPort.Standart(new CreateDisciplineOutput(disciplineId));
        }
    }
}
