using EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Department
{
    public class CreateDisciplinePresenter : ICreateDisciplineOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standart(CreateDisciplineOutput output)
        {
            ViewModel = new OkObjectResult(output.DisciplineId);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
