using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Entities;
using EDU.Domain.Users;
using System.Threading.Tasks;

namespace EDU.Application.UseCases
{
    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IGetUserOutputPort getUserOutputPort;
        private readonly IUserRepository userRepository;

        public GetUserUseCase(IGetUserOutputPort getUserOutputPort, IUserRepository userRepository)
        {
            this.getUserOutputPort = getUserOutputPort;
            this.userRepository = userRepository;
        }

        public async Task Execute(GetUserInput input)
        {
            if (input == null) { getUserOutputPort.WriteError("Is Null"); return; }

            User user = await userRepository.Get(input.UserId);

            if (user == null) { getUserOutputPort.NotFound("Not found"); return; }

            getUserOutputPort.Standart(new GetUserOutput(user));
        }
    }
}
