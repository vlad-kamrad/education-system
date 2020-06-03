using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser
{
    public sealed class RemoveFacultyInput
    {
        public int FacultyId { get; }
        public RemoveFacultyInput(int id) => FacultyId = id;
    }
    public sealed class RemoveFacultyOutput
    {
        public bool Success { get; }
        public RemoveFacultyOutput(bool success) => Success = success;
    }
    public interface IRemoveFacultyOutputPort : IOutputPortStandard<RemoveFacultyOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IRemoveFacultyUseCase : IUseCase<RemoveFacultyInput> { }
}
