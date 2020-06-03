namespace EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase
{
    public class CreateDisciplineOutput
    {
        public int DisciplineId { get; }
        public CreateDisciplineOutput(int disciplineId) => DisciplineId = disciplineId;
    }
}
