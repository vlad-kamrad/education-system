using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Faculty
{
    public class CreateFacultyPresenter : ICreateFacultyOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standart(CreateFacultyOutput output)
        {
            ViewModel = new OkObjectResult(output.FacultyId);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
