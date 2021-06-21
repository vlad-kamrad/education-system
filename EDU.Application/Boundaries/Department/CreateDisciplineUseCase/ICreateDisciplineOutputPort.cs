using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase
{
    public interface ICreateDisciplineOutputPort
    : IOutputPortStandard<CreateDisciplineOutput>, IOutputPortError, IOutputPortNotFound
    { }
}
