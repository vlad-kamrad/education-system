using EDU.Application.Boundaries.Semester;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Semesters
{
    public class UpdateSemesterUseCase : IUpdateSemesterUseCase
    {
        private readonly ISemesterRepository semesterRepository;
        private readonly IUpdateSemesterOutputPort outputPort;

        public UpdateSemesterUseCase(ISemesterRepository semesterRepository, IUpdateSemesterOutputPort outputPort)
        {
            this.semesterRepository = semesterRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(UpdateSemesterInput input)
        {
            if (await semesterRepository.Get(input.UpdatedSemester.Id) == null) { outputPort.NotFound(""); }
            bool success = await semesterRepository.Update(input.UpdatedSemester);
            outputPort.Standart(new UpdateSemesterOutput(success));
        }
    }
}
