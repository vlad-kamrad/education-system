using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser
{
    public sealed class DeleteGroupInput
    {
        public int GroupId { get; }
        public DeleteGroupInput(int groupId) => GroupId = groupId;
    }
    public sealed class DeleteGroupOutput
    {
        public bool Success { get; }
        public DeleteGroupOutput(bool success) => Success = success;
    }
    public interface IDeleteGroupOutputPort : IOutputPortStandard<DeleteGroupOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IDeleteGroupUseCase : IUseCase<DeleteGroupInput> { }
}
