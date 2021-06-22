using EDU.Application.Boundaries.Interfaces;

namespace EDU.Application.Boundaries.GetUser
{
    using User = EDU.Domain.Entities.User;
    public sealed class CreateGroupInput
    {
        public string Title { get; }
        public User Curator { get; }
        public User HeadMan { get; }

        public CreateGroupInput(string Title, User Curator, User HeadMan)
        {
            this.Curator = Curator;
            this.HeadMan = HeadMan;
            this.Title = Title;
        }
    }

    public sealed class CreateGroupOutput 
    {
        public bool Success { get; }
        public CreateGroupOutput(bool success) => Success = success;
    }
    public interface ICreateGroupOutputPort : IOutputPortStandard<CreateGroupOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface ICreateGroupUseCase : IUseCase<CreateGroupInput> { }
}
