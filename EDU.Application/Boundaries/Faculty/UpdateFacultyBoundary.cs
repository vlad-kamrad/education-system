using EDU.Application.Boundaries.Interfaces;
using EDU.Domain.Entities;

namespace EDU.Application.Boundaries.GetUser
{
    public sealed class UpdateFacultyInput
    {
        public Faculty UpdateFaculty { get; }

        public UpdateFacultyInput(Faculty faculty) => UpdateFaculty = faculty;
    }
    public sealed class UpdateFacultyOutput
    {
        public bool Success { get; }
        public UpdateFacultyOutput(bool success) => Success = success;
    }
    public interface IUpdateFacultyOutputPort : IOutputPortStandard<UpdateFacultyOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IUpdateFacultyUseCase : IUseCase<UpdateFacultyInput> { }
}
