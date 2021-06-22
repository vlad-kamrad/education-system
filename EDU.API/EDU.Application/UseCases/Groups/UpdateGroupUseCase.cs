using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Groups
{
    public class UpdateGroupUseCase : IUpdateGroupUseCase
    {
        private readonly IGroupRepository groupRepository;
        private readonly IUpdateGroupOutputPort outputPort;

        public UpdateGroupUseCase(IGroupRepository groupRepository, IUpdateGroupOutputPort outputPort)
        {
            this.groupRepository = groupRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(UpdateGroupInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }
            if (await groupRepository.Get(input.UpdatedGroup.Id) == null) { outputPort.NotFound(""); return; }

            bool success = await groupRepository.Update(input.UpdatedGroup);
            outputPort.Standart(new UpdateGroupOutput(success));
        }
    }
}
