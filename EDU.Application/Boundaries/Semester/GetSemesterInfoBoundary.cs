using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser
{
    using Semester = EDU.Domain.Entities.Semester;
    public sealed class GetSemesterInfoInput
    {
        public int Id { get; }
        public GetSemesterInfoInput(int id) => Id = id;
    }
    public sealed class GetSemesterInfoOutput
    {
        public Semester Semester { get; }
        public GetSemesterInfoOutput(Semester semester) => Semester = semester;
    }
    public interface IGetSemesterInfoOutputPort : IOutputPortStandard<GetSemesterInfoOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IGetSemesterInfoUseCase : IUseCase<GetSemesterInfoInput> { }
}
