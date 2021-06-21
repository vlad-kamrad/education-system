using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.Group
{
    public class DeleteGroupPresenter : IDeleteGroupOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standart(DeleteGroupOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
