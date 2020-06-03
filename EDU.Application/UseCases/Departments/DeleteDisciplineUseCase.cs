using EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Departments
{
    public class DeleteDisciplineUseCase : IDeleteDisciplineUseCase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IDeleteDisciplineOutputPort outputPort;

        public DeleteDisciplineUseCase(IDepartmentRepository departmentRepository, IDeleteDisciplineOutputPort outputPort)
        {
            this.departmentRepository = departmentRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(DeleteDisciplineInput input)
        {
            if (input == null) { outputPort.WriteError(""); }
            if (await departmentRepository.GetDiscipline(input.DisciplineId) == null) { outputPort.NotFound(""); }

            bool success = await departmentRepository.RemoveDiscipline(input.DisciplineId);
            outputPort.Standart(new DeleteDisciplineOutput(success));
        }
    }
}
