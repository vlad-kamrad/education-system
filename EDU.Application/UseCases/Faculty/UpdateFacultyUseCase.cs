using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Faculty
{
    public class UpdateFacultyUseCase : IUpdateFacultyUseCase
    {
        private readonly IFacultyRepository facultyRepository;
        private readonly IUpdateFacultyOutputPort outputPort;

        public UpdateFacultyUseCase(IFacultyRepository facultyRepository, IUpdateFacultyOutputPort outputPort)
        {
            this.facultyRepository = facultyRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(UpdateFacultyInput input)
        {
            if (await facultyRepository.Get(input.UpdateFaculty.Id) == null) { outputPort.NotFound(""); }

            bool success = await facultyRepository.Update(input.UpdateFaculty);
            outputPort.Standart(new UpdateFacultyOutput(success));
        }
    }
}
