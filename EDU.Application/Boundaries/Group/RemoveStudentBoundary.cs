using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.Group
{
    public sealed class RemoveStudentInput
    {
        public int GroupId { get; }
        public int StudentId { get; }
        public RemoveStudentInput(int GroupId, int StudentId)
        {
            this.GroupId = GroupId;
            this.StudentId = StudentId;
        }
    }
    public sealed class RemoveStudentOutput
    {
        public bool Success { get; }
        public RemoveStudentOutput(bool success) => Success = success;
    }
    public interface IRemoveStudentOutputPort : IOutputPortStandard<RemoveStudentOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IRemoveStudentUseCase : IUseCase<RemoveStudentInput> { }
}
