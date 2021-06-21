using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.User
{
    public sealed class CreateUserInput
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public CreateUserInput(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
    public sealed class CreateUserOutput
    {
        public bool Success { get; }
        public CreateUserOutput(bool success) => Success = success;
    }
    public interface ICreateUserOutputPort : IOutputPortStandard<CreateUserOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface ICreateUserUseCase : IUseCase<CreateUserInput> { }
}
