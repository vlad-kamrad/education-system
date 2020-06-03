using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase
{
    public interface ICreateDepartmentOutputPort : IOutputPortStandard<CreateDepartmentOutput>, IOutputPortError, IOutputPortNotFound { }
}
