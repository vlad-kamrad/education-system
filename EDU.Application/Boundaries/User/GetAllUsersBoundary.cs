using EDU.Application.Boundaries.Interfaces;
using EDU.Domain.Entities;
using System.Collections;
using System.Collections.Generic;

namespace EDU.Application.Boundaries.User
{
    using User = EDU.Domain.Entities.User;
    public sealed class GetAllUsersInput { }
    public sealed class GetAllUsersOutput { 
        public IList<User> Users { get; }
        public GetAllUsersOutput(IList<User> Users) => this.Users = Users;

    }
    public interface IGetAllUsersOutputPort : IOutputPortStandard<GetAllUsersOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IGetAllUsersUseCase : IUseCase<GetAllUsersInput> { }
}
