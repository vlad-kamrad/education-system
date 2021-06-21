namespace EDU.Application.Boundaries.Department.UpdateDepartmentUseCase
{
    public class UpdateDepartmentOutput
    {
        public bool Success { get; }
        public UpdateDepartmentOutput(bool success) => Success = success;
    }
}
