﻿using EDU.Application.Boundaries.User;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.User
{
    public class ChangeRolePresenter : IChangeRoleOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();
        public void NotFound(string message) => ViewModel = new NotFoundObjectResult(message);
        public void Standart(ChangeRoleOutput output) => ViewModel = new OkObjectResult(output.Success);
        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(message);
    }
}
