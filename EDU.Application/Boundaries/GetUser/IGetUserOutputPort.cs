using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser
{
    public interface IGetUserOutputPort : IOutputPortStandard<GetUserOutput>, IOutputPortError, IOutputPortNotFound { }
}
