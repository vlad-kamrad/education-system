using EDU.Application.Boundaries.Department;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.Semester
{
    public class CreateEducationalCoursePresenter : ICreateEducationalCourseOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();
        public void NotFound(string message) => ViewModel = new NotFoundObjectResult(message);
        public void Standart(CreateEducationalCourseOutput output) => ViewModel = new OkObjectResult(output.Success);
        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(message);
    }
}
