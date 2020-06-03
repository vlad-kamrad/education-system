using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.Department.UpdateDepartmentUseCase
{
    public interface IUpdateDepartmentOutputPort
        : IOutputPortStandard<UpdateDepartmentOutput>, IOutputPortError, IOutputPortNotFound
    { }
}
