using EDU.Application.Boundaries.Semester;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Semesters
{
    public class RemoveSemesterUseCase : IRemoveSemesterUseCase
    {
        private readonly ISemesterRepository semesterRepository;
        private readonly IRemoveSemesterOutputPort outputPort;

        public RemoveSemesterUseCase(ISemesterRepository semesterRepository, IRemoveSemesterOutputPort outputPort)
        {
            this.semesterRepository = semesterRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(RemoveSemesterInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            bool sucess = await semesterRepository.Remove(input.Id);
            outputPort.Standart(new RemoveSemesterOutput(sucess));
        }
    }
}
