using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Semesters
{
    public class GetSemesterInfoUseCase : IGetSemesterInfoUseCase
    {
        private readonly ISemesterRepository semesterRepository;
        private readonly IGetSemesterInfoOutputPort outputPort;

        public GetSemesterInfoUseCase(ISemesterRepository semesterRepository, IGetSemesterInfoOutputPort outputPort)
        {
            this.semesterRepository = semesterRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(GetSemesterInfoInput input)
        {
            var result = await semesterRepository.Get(input.Id);
            if (result == null) { outputPort.NotFound(""); }
            outputPort.Standart(new GetSemesterInfoOutput(result));
        }
    }
}
