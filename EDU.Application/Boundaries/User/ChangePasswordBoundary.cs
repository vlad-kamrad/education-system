using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.User
{
    public sealed class ChangePasswordInput
    {
        public int UserId { get; }
        public string NewPassword { get; }
        public ChangePasswordInput(int userId, string newPassword)
        {
            UserId = userId;
            NewPassword = newPassword;
        }
    }
    public sealed class ChangePasswordOutput
    {
        public bool Success { get; }
        public ChangePasswordOutput(bool success) => Success = success;
    }
    public interface IChangePasswordOutputPort : IOutputPortStandard<ChangePasswordOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IChangePasswordUseCase : IUseCase<ChangePasswordInput> { }
}
