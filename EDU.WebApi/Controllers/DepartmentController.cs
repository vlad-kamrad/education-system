using EDU.Application.Boundaries.Department;
using EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase;
using EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.GetAllDepartments;
using EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase;
using EDU.Application.Boundaries.GetUser.UpdateDepartmentUseCase;
using EDU.Domain.Entities;
using EDU.WebApi.Presenters;
using EDU.WebApi.Presenters.Department;
using EDU.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDU.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments(
            [FromServices] IGetAllDepartmentsUseCase getAllDepartmentsUseCase,
            [FromServices] GetAllDepartmentsPresenter getAllDepartmentsPresenter)
        {
            await getAllDepartmentsUseCase.Execute(new GetAllDepartmentsInput());
            return getAllDepartmentsPresenter.ViewModel;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDepartment(
            [FromServices] ICreateDepartmentUseCase createDepartmentUseCase,
            [FromServices] CreateDepartmentPresenter createDepartmentPresenter,
            [FromBody] CreateDepartmentRequest input)
        {
            await createDepartmentUseCase.Execute(new CreateDepartmentInput(input.Name, input.HeadId));
            return createDepartmentPresenter.ViewModel;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(
            [FromServices] IUpdateDepartmentUseCase updateDepartmentUseCase,
            [FromServices] UpdateDepartmentPresenter updateDepartmentPresenter,
            [FromBody] Department input)
        {
            await updateDepartmentUseCase.Execute(new UpdateDepartmentInput(input));
            return updateDepartmentPresenter.ViewModel;
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveDepartment(
            [FromServices] IRemoveDepartmentUseCase removeDepartmentUseCase,
            [FromServices] RemoveDepartmentPresenter removeDepartmentPresenter,
            [FromBody] RequestId input)
        {
            await removeDepartmentUseCase.Execute(new RemoveDepartmentInput(input.Id));
            return removeDepartmentPresenter.ViewModel;
        }

        // Disciplines in current department
        // Create dis in dep
        [HttpPost]
        public async Task<IActionResult> CreateDiscipline(
            [FromServices] ICreateDisciplineUseCase createDisciplineUseCase,
            [FromServices] CreateDisciplinePresenter createDisciplinePresenter,
            [FromBody] CreateDisciplineRequest input)
        {
            await createDisciplineUseCase.Execute(new CreateDisciplineInput(input.DepartmentId, input.Name, input.Description));
            return createDisciplinePresenter.ViewModel;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscipline(
            [FromServices] IDeleteDisciplineUseCase deleteDisciplineUseCase,
            [FromServices] DeleteDisciplinePresenter deleteDisciplinePresenter,
            [FromBody] RequestId input)
        {
            await deleteDisciplineUseCase.Execute(new DeleteDisciplineInput(input.Id));
            return deleteDisciplinePresenter.ViewModel;
        }
    }
}