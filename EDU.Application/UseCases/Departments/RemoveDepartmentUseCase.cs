using EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase;
using EDU.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Departments
{
    public class RemoveDepartmentUseCase : IRemoveDepartmentUseCase
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IRemoveDepartmentOutputPort outputPort;

        public RemoveDepartmentUseCase(IRemoveDepartmentOutputPort outputPort, IDepartmentRepository departmentRepository)
        {
            this.outputPort = outputPort;
            this.departmentRepository = departmentRepository;
        }

        public async Task Execute(RemoveDepartmentInput input)
        {
            if (input == null) { outputPort.WriteError(""); }
            if (await departmentRepository.GetDepartment(input.DepartmentId) == null) { outputPort.NotFound(""); }

            bool success = await departmentRepository.Remove(input.DepartmentId);
            outputPort.Standart(new RemoveDepartmentOutput(success));
        }
    }
}
