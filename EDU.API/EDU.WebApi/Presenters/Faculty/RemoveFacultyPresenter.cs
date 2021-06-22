using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Faculty
{
    public class RemoveFacultyPresenter : IRemoveFacultyOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundResult();
        }

        public void Standart(RemoveFacultyOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
