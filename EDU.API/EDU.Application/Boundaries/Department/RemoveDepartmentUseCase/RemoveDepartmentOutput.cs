namespace EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase
{
    public class RemoveDepartmentOutput
    {
        public bool Success { get; }
        public RemoveDepartmentOutput(bool success) => Success = success;
    }
}
