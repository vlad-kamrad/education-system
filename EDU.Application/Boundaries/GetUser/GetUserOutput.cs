using EDU.Domain.Entities;

namespace EDU.Application.Boundaries.GetUser
{
    public sealed class GetUserOutput
    {
        public Domain.Entities.User User { get; }
        public GetUserOutput(Domain.Entities.User user) => User = user;
    }
}
