using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.Department
{
    using User = EDU.Domain.Entities.User;
    public sealed class CreateEducationalCourseInput
    {
        public User Teacher { get; }
        public string Description { get; }

        public CreateEducationalCourseInput(User Teacher, string Description)
        {
            this.Teacher = Teacher;
            this.Description = Description;
        }
    }
    public sealed class CreateEducationalCourseOutput
    {
        public bool Success { get; }
        public CreateEducationalCourseOutput(bool success) => Success = success;
    }
    public interface ICreateEducationalCourseOutputPort : IOutputPortStandard<CreateEducationalCourseOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface ICreateEducationalCourseUseCase : IUseCase<CreateEducationalCourseInput> { }
}
