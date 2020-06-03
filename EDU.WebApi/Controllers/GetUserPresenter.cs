using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Controllers
{
    public class GetUserPresenter : IGetUserOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standart(GetUserOutput output)
        {
            ViewModel = new OkObjectResult(output.User);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
