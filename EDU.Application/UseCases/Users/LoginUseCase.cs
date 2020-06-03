using EDU.Application.Boundaries.User;
using EDU.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Users
{
    public class LoginUseCase : ILoginUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly ILoginOutputPort outputPort;
        private readonly IAuthService authService;

        public LoginUseCase(
            IUserRepository userRepository,
            ILoginOutputPort outputPort,
            IAuthService authService)
        {
            this.userRepository = userRepository;
            this.outputPort = outputPort;
            this.authService = authService;
        }
        public async Task Execute(LoginInput input)
        {
            if (await userRepository.Get(input.Username) == null) { outputPort.NotFound($"User {input.Username} Not Found"); }

            var token = await authService.GenerateAccessToken(input.Username, input.Password);
            outputPort.Standart(new LoginOutput(token));
        }
    }
}
