using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.Group
{
    public sealed class AddStudentInput
    {
        public int GroupId { get; }
        public int StudentId { get; }
        public AddStudentInput(int GroupId, int StudentId)
        {
            this.GroupId = GroupId;
            this.StudentId = StudentId;
        }
    }
    public sealed class AddStudentOutput
    {
        public bool Success { get; }
        public AddStudentOutput(bool success) => Success = success;
    }
    public interface IAddStudentOutputPort : IOutputPortStandard<AddStudentOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IAddStudentUseCase : IUseCase<AddStudentInput> { }
}
