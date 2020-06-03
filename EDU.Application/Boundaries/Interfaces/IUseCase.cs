using System.Threading.Tasks;

namespace EDU.Application.Boundaries
{
    public interface IUseCase<in TUseCaseInput>
    {
        Task Execute(TUseCaseInput input);
    }
}
