using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser.GetFacultiesUseCase
{
    public interface IGetFacultiesOutputPort
        : IOutputPortStandard<GetFacultiesOutput>, IOutputPortError, IOutputPortNotFound
    { }
}
