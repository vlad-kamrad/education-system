using EDU.Domain.Entities;

namespace EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase
{
    public class CreateDepartmentInput
    {
        public string Name { get; }
        public int HeadId { get; }

        public CreateDepartmentInput(string name, int headId)
        {
            Name = name;
            HeadId = headId;
        }
    }
}
