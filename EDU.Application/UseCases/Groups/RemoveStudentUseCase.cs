using EDU.Application.Boundaries.Group;
using EDU.Domain.Repositories;
using EDU.Domain.Users;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Groups
{
    public class RemoveStudentUseCase : IRemoveStudentUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IRemoveStudentOutputPort outputPort;

        public RemoveStudentUseCase(
            IGroupRepository groupRepository,
            IRemoveStudentOutputPort outputPort,
            IUserRepository userRepository)
        {
            this.groupRepository = groupRepository;
            this.userRepository = userRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(RemoveStudentInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            if (
               await groupRepository.Get(input.GroupId) == null ||
               await userRepository.Get(input.StudentId) == null
              ) { outputPort.NotFound(""); return; }

            bool success = await groupRepository.RemoveStudent(input.GroupId, input.StudentId);
            outputPort.Standart(new RemoveStudentOutput(success));
        }
    }
}
