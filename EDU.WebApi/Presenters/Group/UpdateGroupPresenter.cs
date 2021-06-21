using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.Group
{
    public class UpdateGroupPresenter : IUpdateGroupOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standart(UpdateGroupOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
