using EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters
{
    public class CreateDepartmentPresenter : ICreateDepartmentOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standart(CreateDepartmentOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
