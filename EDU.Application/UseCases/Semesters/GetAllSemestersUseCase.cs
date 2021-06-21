using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Semesters
{
    public class GetAllSemestersUseCase : IGetAllSemestersUseCase
    {
        private readonly ISemesterRepository semesterRepository;
        private readonly IGetAllSemestersOutputPort outputPort;

        public GetAllSemestersUseCase(ISemesterRepository semesterRepository, IGetAllSemestersOutputPort outputPort)
        {
            this.semesterRepository = semesterRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(GetAllSemestersInput input)
        {
            var result = await semesterRepository.Get();
            outputPort.Standart(new GetAllSemestersOutput(result));
        }
    }
}
