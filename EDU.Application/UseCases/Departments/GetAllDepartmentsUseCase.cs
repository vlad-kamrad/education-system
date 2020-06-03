using EDU.Application.Boundaries.GetUser.GetAllDepartments;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Departments
{
    public class GetAllDepartmentsUseCase : IGetAllDepartmentsUseCase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IGetAllDepartmentsOutputPort outputPort;

        public GetAllDepartmentsUseCase(IDepartmentRepository departmentRepository, IGetAllDepartmentsOutputPort outputPort)
        {
            this.departmentRepository = departmentRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(GetAllDepartmentsInput input)
        {
            var result = await departmentRepository.GetDepartments();
            outputPort.Standart(new GetAllDepartmentsOutput(result));
        }
    }
}
