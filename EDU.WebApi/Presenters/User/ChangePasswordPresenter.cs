using EDU.Application.Boundaries.User;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.User
{
    public class ChangePasswordPresenter : IChangePasswordOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();
        public void NotFound(string message) => ViewModel = new NotFoundObjectResult(message);
        public void Standart(ChangePasswordOutput output) => ViewModel = new OkObjectResult(output.Success);
        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(message);
    }
}
