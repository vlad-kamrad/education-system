using EDU.Application.Boundaries.User;
using EDU.Domain.Users;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Users
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly ICreateUserOutputPort outputPort;
        private readonly IPasswordHasher passwordHasher;

        public CreateUserUseCase(
            IUserRepository userRepository,
            ICreateUserOutputPort outputPort,
            IPasswordHasher passwordHasher)
        {
            this.userRepository = userRepository;
            this.passwordHasher = passwordHasher;
            this.outputPort = outputPort;
        }

        public async Task Execute(CreateUserInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            bool success = await userRepository.Create(
                input.Username,
                passwordHasher.EncodePassword(input.Password),
                input.Email
            );

            outputPort.Standart(new CreateUserOutput(success));
        }
    }
}
