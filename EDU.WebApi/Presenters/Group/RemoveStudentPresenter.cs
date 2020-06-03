using EDU.Application.Boundaries.Group;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.Group
{
    public class RemoveStudentPresenter : IRemoveStudentOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standart(RemoveStudentOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
