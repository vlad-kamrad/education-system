using EDU.Application.Boundaries.Interfaces;
using EDU.Domain.Entities;
using User = EDU.Domain.Entities.User;

namespace EDU.Application.Boundaries.GetUser
{
    public sealed class CreateFacultyInput
    {//ILoginUseCase
        public string Title { get; }
        public Domain.Entities.User Head { get; }
        public Domain.Entities.User Subhead { get; }

        public CreateFacultyInput(string Title, Domain.Entities.User Head, Domain.Entities.User Subhead)
        {
            this.Title = Title;
            this.Head = Head;
            this.Subhead = Subhead;
        }
    }

    public sealed class CreateFacultyOutput
    {
        public int FacultyId { get; }

        public CreateFacultyOutput(int facultyId) => FacultyId = facultyId;
    }
    public interface ICreateFacultyOutputPort : IOutputPortStandard<CreateFacultyOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface ICreateFacultyUseCase : IUseCase<CreateFacultyInput> { }
}
