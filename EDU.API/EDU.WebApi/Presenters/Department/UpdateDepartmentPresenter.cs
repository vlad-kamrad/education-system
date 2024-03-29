﻿using EDU.Application.Boundaries.Department.UpdateDepartmentUseCase;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDU.WebApi.Presenters.Department
{
    public class UpdateDepartmentPresenter : IUpdateDepartmentOutputPort
    {
        public IActionResult ViewModel { get; private set; } = new NoContentResult();

        public void NotFound(string message)
        {
            ViewModel = new NotFoundResult();
        }

        public void Standart(UpdateDepartmentOutput output)
        {
            ViewModel = new OkObjectResult(output.Success);
        }

        public void WriteError(string message)
        {
            ViewModel = new BadRequestObjectResult(message);
        }
    }
}
