using EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Department
{
    public class RemoveDepartmentPresenter : IRemoveDepartmentOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standart(RemoveDepartmentOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
