using EDU.Application.Boundaries.Group;
using EDU.Domain.Repositories;
using EDU.Domain.Users;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Groups
{
    // Add Student To Group
    public class AddStudentUseCase : IAddStudentUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IAddStudentOutputPort outputPort;

        public AddStudentUseCase(
            IGroupRepository groupRepository,
            IUserRepository userRepository,
            IAddStudentOutputPort outputPort)
        {
            this.groupRepository = groupRepository;
            this.userRepository = userRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(AddStudentInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            if (
                await groupRepository.Get(input.GroupId) == null ||
                await userRepository.Get(input.StudentId) == null
               ) { outputPort.NotFound(""); return; }

            bool success = await groupRepository.AddStudent(input.GroupId, input.StudentId);
            outputPort.Standart(new AddStudentOutput(success));
        }
    }
}
