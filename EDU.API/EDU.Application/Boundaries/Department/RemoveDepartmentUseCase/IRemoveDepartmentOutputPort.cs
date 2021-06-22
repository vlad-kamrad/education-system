using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase
{
    public interface IRemoveDepartmentOutputPort
        : IOutputPortStandard<RemoveDepartmentOutput>, IOutputPortError, IOutputPortNotFound
    { }
}
