namespace EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase
{
    public class DeleteDisciplineOutput
    {
        public bool Success { get; }
        public DeleteDisciplineOutput(bool success) => Success = success;
    }
}
