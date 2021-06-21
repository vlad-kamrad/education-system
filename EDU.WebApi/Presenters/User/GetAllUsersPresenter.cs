using EDU.Application.Boundaries.User;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.User
{
    public class GetAllUsersPresenter : IGetAllUsersOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();
        public void NotFound(string message) => ViewModel = new NotFoundObjectResult(message);
        public void Standart(GetAllUsersOutput output) => ViewModel = new OkObjectResult(output.Users);
        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(message);
    }
}
