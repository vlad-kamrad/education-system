namespace EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase
{
    public class CreateDepartmentOutput
    {
        public bool Success { get; }
        public CreateDepartmentOutput(bool success) => Success = success;
    }
}
