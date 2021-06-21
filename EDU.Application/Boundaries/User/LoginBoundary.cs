using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.User
{
    public sealed class LoginInput
    {
        public string Username { get; }
        public string Password { get; }
        public LoginInput(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
    public sealed class LoginOutput
    {
        public string Token { get; }
        public LoginOutput(string token) => Token = token;
    }
    public interface ILoginOutputPort : IOutputPortStandard<LoginOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface ILoginUseCase : IUseCase<LoginInput> { }
}
