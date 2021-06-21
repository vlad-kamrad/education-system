using EDU.Application.Boundaries.GetUser.GetAllDepartments;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Department
{
    public class GetAllDepartmentsPresenter : IGetAllDepartmentsOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundResult();
        }

        public void Standart(GetAllDepartmentsOutput output)
        {
            ViewModel = new OkObjectResult(output.Departments);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
