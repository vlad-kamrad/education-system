using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Faculty
{
    public class RemoveFacultyUseCase : IRemoveFacultyUseCase
    {
        private readonly IFacultyRepository facultyRepository;
        private readonly IRemoveFacultyOutputPort outputPort;

        public RemoveFacultyUseCase(IFacultyRepository facultyRepository, IRemoveFacultyOutputPort outputPort)
        {
            this.facultyRepository = facultyRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(RemoveFacultyInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            if (await facultyRepository.Get(input.FacultyId) == null) { outputPort.NotFound(""); return; }

            bool success = await facultyRepository.Remove(input.FacultyId);
            outputPort.Standart(new RemoveFacultyOutput(success));
        }
    }
}
