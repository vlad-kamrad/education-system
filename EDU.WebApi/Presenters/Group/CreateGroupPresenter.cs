using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Group
{
    public class CreateGroupPresenter : ICreateGroupOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundResult();
        }

        public void Standart(CreateGroupOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
