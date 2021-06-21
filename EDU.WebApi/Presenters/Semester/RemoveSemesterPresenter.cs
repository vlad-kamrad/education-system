using EDU.Application.Boundaries.Semester;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.Semester
{
    public class RemoveSemesterPresenter : IRemoveSemesterOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();
        public void NotFound(string message) => ViewModel = new NotFoundObjectResult(message);
        public void Standart(RemoveSemesterOutput output) => ViewModel = new OkObjectResult(output.Success);
        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(message);
    }
}
