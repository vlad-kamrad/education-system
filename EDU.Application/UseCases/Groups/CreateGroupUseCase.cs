using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Groups
{
    public class CreateGroupUseCase : ICreateGroupUseCase
    {
        private readonly IGroupRepository groupRepository;
        private readonly ICreateGroupOutputPort outputPort;

        public CreateGroupUseCase(IGroupRepository groupRepository, ICreateGroupOutputPort outputPort)
        {
            this.groupRepository = groupRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(CreateGroupInput input)
        {
            if (input == null) { outputPort.WriteError(""); }

            bool success = await groupRepository.Create(input.Title, input.Curator, input.HeadMan);
            outputPort.Standart(new CreateGroupOutput(success));
        }
    }
}
