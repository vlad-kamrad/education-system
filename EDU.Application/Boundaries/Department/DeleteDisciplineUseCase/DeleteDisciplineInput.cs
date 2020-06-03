namespace EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase
{
    public class DeleteDisciplineInput
    {
        public int DisciplineId { get; }
        public DeleteDisciplineInput(int disciplineId) => DisciplineId = disciplineId;
    }
}
