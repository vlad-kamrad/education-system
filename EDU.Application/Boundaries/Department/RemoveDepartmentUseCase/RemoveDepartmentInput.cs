namespace EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase
{
    public class RemoveDepartmentInput
    {
        public int DepartmentId { get; }
        public RemoveDepartmentInput(int departmentId) => DepartmentId = departmentId;
    }
}
