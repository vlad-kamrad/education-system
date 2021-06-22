using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Faculty
{
    public class CreateFacultyUseCase : ICreateFacultyUseCase
    {
        private readonly IFacultyRepository facultyRepository;
        private readonly ICreateFacultyOutputPort outputPort;

        public CreateFacultyUseCase(IFacultyRepository facultyRepository, ICreateFacultyOutputPort outputPort)
        {
            this.facultyRepository = facultyRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(CreateFacultyInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            int facultyId = await facultyRepository.Create(input.Title, input.Head, input.Subhead);

            outputPort.Standart(new CreateFacultyOutput(facultyId));
        }
    }
}
