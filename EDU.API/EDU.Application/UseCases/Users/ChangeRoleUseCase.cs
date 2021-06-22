using EDU.Application.Boundaries.User;
using EDU.Domain.Users;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Users
{
    public class ChangeRoleUseCase : IChangeRoleUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IChangeRoleOutputPort outputPort;

        public ChangeRoleUseCase(IUserRepository userRepository, IChangeRoleOutputPort outputPort)
        {
            this.userRepository = userRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(ChangeRoleInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            var user = await userRepository.Get(input.UserId);
            if (user == null) { outputPort.NotFound(""); return; }

            bool success = await userRepository.ChangeRole(user.Id, input.RolesId);
            outputPort.Standart(new ChangeRoleOutput(success));
        }
    }
}
