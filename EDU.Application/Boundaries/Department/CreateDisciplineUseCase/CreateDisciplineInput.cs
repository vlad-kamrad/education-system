namespace EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase
{
    public class CreateDisciplineInput
    {
        public int DepartmentId { get; }
        public string Name { get; }
        public string Description { get; }

        public CreateDisciplineInput(int departmentId, string name, string description)
        {
            DepartmentId = departmentId;
            Name = name;
            Description = description;
        }
    }
}
