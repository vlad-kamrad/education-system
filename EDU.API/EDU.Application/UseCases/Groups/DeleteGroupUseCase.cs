using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Groups
{
    public class DeleteGroupUseCase : IDeleteGroupUseCase
    {
        private readonly IGroupRepository groupRepository;
        private readonly IDeleteGroupOutputPort outputPort;

        public DeleteGroupUseCase(IGroupRepository groupRepository, IDeleteGroupOutputPort outputPort)
        {
            this.groupRepository = groupRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(DeleteGroupInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }
            if (await groupRepository.Get(input.GroupId) == null) { outputPort.NotFound(""); return; }

            bool success = await groupRepository.Remove(input.GroupId);
            outputPort.Standart(new DeleteGroupOutput(success));
        }
    }
}
