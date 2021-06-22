using EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase;
using EDU.Domain.Entities;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Departments
{
    public class CreateDepartmentUseCase : ICreateDepartmentUseCase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICreateDepartmentOutputPort createDepartmentOutputPort;

        public CreateDepartmentUseCase(ICreateDepartmentOutputPort createDepartmentOutputPort, IDepartmentRepository departmentRepository)
        {
            this.createDepartmentOutputPort = createDepartmentOutputPort;
            this.departmentRepository = departmentRepository;
        }

        public async Task Execute(CreateDepartmentInput input)
        {
            if (input == null) { createDepartmentOutputPort.WriteError("Department is empty"); return; }


            // Vajno!!!
          //  var user = findUser trtatata 

            bool isSuccess = await departmentRepository.Create(new Department()
            {
                Head = new User() { Id = input.HeadId },
                Name = input.Name
            });

            createDepartmentOutputPort.Standart(new CreateDepartmentOutput(isSuccess));
        }
    }
}
