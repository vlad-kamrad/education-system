using EDU.Application.Boundaries.Interfaces;
using System.Collections.Generic;

namespace EDU.Application.Boundaries.GetUser
{
    using Group = EDU.Domain.Entities.Group;
    public sealed class GetAllGroupsInput { }
    public sealed class GetAllGroupsOutput
    {
        public IList<Group> Groups { get; }
        public GetAllGroupsOutput(IList<Group> groups) => Groups = groups;
    }
    public interface IGetAllGroupsOutputPort : IOutputPortStandard<GetAllGroupsOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IGetAllGroupsUseCase : IUseCase<GetAllGroupsInput> { }
}
