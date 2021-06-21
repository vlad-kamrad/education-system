using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.Semester
{
    public sealed class RemoveSemesterInput
    {
        public int Id { get; }
        public RemoveSemesterInput(int id) => Id = id;
    }
    public sealed class RemoveSemesterOutput
    {
        public bool Success { get; }
        public RemoveSemesterOutput(bool success) => Success = success;
    }
    public interface IRemoveSemesterOutputPort : IOutputPortStandard<RemoveSemesterOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IRemoveSemesterUseCase : IUseCase<RemoveSemesterInput> { }
}
