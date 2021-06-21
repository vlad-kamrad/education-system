using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Group
{
    public class GetAllGroupsPresenter : IGetAllGroupsOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            throw new NotImplementedException();
        }

        public void Standart(GetAllGroupsOutput output)
        {
            ViewModel = new OkObjectResult(output.Groups);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
