using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Entities;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Semesters
{
    public class CreateSemesterUseCase : ICreateSemesterUseCase
    {
        private readonly ISemesterRepository semesterRepository;
        private readonly ICreateSemesterOutputPort outputPort;

        public CreateSemesterUseCase(ISemesterRepository semesterRepository, ICreateSemesterOutputPort outputPort)
        {
            this.semesterRepository = semesterRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(CreateSemesterInput input)
        {
            bool success = await semesterRepository.Create(
                new Semester() { StartDate = input.Start, EndDate = input.End });
            outputPort.Standart(new CreateSemesterOutput(success));
        }
    }
}
