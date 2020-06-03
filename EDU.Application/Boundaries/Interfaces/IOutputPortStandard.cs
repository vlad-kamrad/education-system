namespace EDU.Application.Boundaries.Interfaces
{
    public interface IOutputPortStandard<in TUseCaseOutput>
    {
        void Standart(TUseCaseOutput output);
    }
}
