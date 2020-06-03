using EDU.Application.Boundaries.User;
using EDU.Domain.Users;
using System.Linq;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Users
{
    public class GetAllUsersUseCase : IGetAllUsersUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IGetAllUsersOutputPort outputPort;

        public GetAllUsersUseCase(IUserRepository userRepository, IGetAllUsersOutputPort outputPort)
        {
            this.userRepository = userRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(GetAllUsersInput input)
        {
            var result = await userRepository.Get();
            outputPort.Standart(new GetAllUsersOutput(result.ToList()));
        }
    }
}
