using EDU.Application.Boundaries.GetUser.GetFacultiesUseCase;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Faculty
{
    public class GetAllFacultiesPresenter : IGetFacultiesOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standart(GetFacultiesOutput output)
        {
            ViewModel = new OkObjectResult(output.Faculties);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
