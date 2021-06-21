using EDU.Application.Boundaries.Group;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.Group
{
    public class AddStudentPresenter : IAddStudentOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standart(AddStudentOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
