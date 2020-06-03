using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser
{
    using Group = EDU.Domain.Entities.Group;
    public sealed class UpdateGroupInput
    {
        public Group UpdatedGroup { get; }
        public UpdateGroupInput(Group group) => UpdatedGroup = group;
    }
    public sealed class UpdateGroupOutput
    {
        public bool Success { get; }
        public UpdateGroupOutput(bool success) => Success = success;
    }
    public interface IUpdateGroupOutputPort : IOutputPortStandard<UpdateGroupOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IUpdateGroupUseCase : IUseCase<UpdateGroupInput> { }
}
