using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDU.WebApi.Presenters.Semester
{
    public class GetAllSemestersPresenter : IGetAllSemestersOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundObjectResult(message);
        }

        public void Standart(GetAllSemestersOutput output)
        {
            ViewModel = new OkObjectResult(output.Semesters);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
