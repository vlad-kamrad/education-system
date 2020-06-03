using EDU.Application.Boundaries.Interfaces;
using System.Collections.Generic;

namespace EDU.Application.Boundaries.User
{
    public sealed class ChangeRoleInput
    {
        public int UserId { get; }
        public IList<int> RolesId { get; }
        public ChangeRoleInput(int userId, int[] rolesId)
        {
            UserId = userId;
            RolesId = rolesId;
        }
    }
    public sealed class ChangeRoleOutput
    {
        public bool Success { get; }
        public ChangeRoleOutput(bool success) => Success = success;
    }
    public interface IChangeRoleOutputPort : IOutputPortStandard<ChangeRoleOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IChangeRoleUseCase : IUseCase<ChangeRoleInput> { }
}
