using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser.GetAllDepartments
{
    public interface IGetAllDepartmentsOutputPort
        : IOutputPortStandard<GetAllDepartmentsOutput>, IOutputPortError, IOutputPortNotFound
    { }
}
