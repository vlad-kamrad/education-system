using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase
{
    public interface IDeleteDisciplineOutputPort
        : IOutputPortStandard<DeleteDisciplineOutput>, IOutputPortError, IOutputPortNotFound
    { }
}
