﻿using EDU.Application.Boundaries.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace EDU.WebApi.Presenters.Semester
{
    public class GetSemesterInfoPresenter : IGetSemesterInfoOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();
        public void NotFound(string message) => ViewModel = new NotFoundObjectResult(message);
        public void Standart(GetSemesterInfoOutput output) => ViewModel = new OkObjectResult(output.Semester);
        public void WriteError(string message) => ViewModel = new BadRequestObjectResult(message);
    }
}
