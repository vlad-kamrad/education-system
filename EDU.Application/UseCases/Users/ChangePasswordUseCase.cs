using EDU.Application.Boundaries.User;
using EDU.Domain.Users;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Users
{
    public class ChangePasswordUseCase : IChangePasswordUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IChangePasswordOutputPort outputPort;
        private readonly IPasswordHasher passwordHasher;

        public ChangePasswordUseCase(
            IUserRepository userRepository,
            IChangePasswordOutputPort outputPort,
            IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.outputPort = outputPort;
        }

        public async Task Execute(ChangePasswordInput input)
        {
            var user = await userRepository.Get(input.UserId);
            if (user == null) { outputPort.NotFound(""); }

            user.Password = passwordHasher.EncodePassword(input.NewPassword);
            bool success = await userRepository.Update(user);

            outputPort.Standart(new ChangePasswordOutput(success));
        }
    }
}
