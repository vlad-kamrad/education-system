using EDU.Application.Boundaries.GetUser.GetFacultiesUseCase;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Faculty
{
    public class GetFacultiesUseCase : IGetFacultiesUseCase
    {
        private readonly IFacultyRepository facultyRepository;
        private readonly IGetFacultiesOutputPort outputPort;

        public GetFacultiesUseCase(IFacultyRepository facultyRepository, IGetFacultiesOutputPort outputPort)
        {
            this.facultyRepository = facultyRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(GetFacultiesInput input)
        {
            var result = await facultyRepository.Get();
            outputPort.Standart(new GetFacultiesOutput(result));
        }
    }
}
