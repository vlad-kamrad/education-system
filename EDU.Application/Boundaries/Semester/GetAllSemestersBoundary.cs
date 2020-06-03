using EDU.Application.Boundaries.Interfaces;
using System.Collections.Generic;

namespace EDU.Application.Boundaries.GetUser
{
    using Semester = EDU.Domain.Entities.Semester;
    public sealed class GetAllSemestersInput { }
    public sealed class GetAllSemestersOutput
    {
        public List<Semester> Semesters { get; }
        public GetAllSemestersOutput(List<Semester> semesters) => Semesters = semesters;
    }
    public interface IGetAllSemestersOutputPort : IOutputPortStandard<GetAllSemestersOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IGetAllSemestersUseCase : IUseCase<GetAllSemestersInput> { }
}
