using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.GetUser.GetFacultiesUseCase;
using EDU.Domain.Entities;
using EDU.WebApi.Presenters.Faculty;
using EDU.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDU.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultyController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllFaculties(
            [FromServices] IGetFacultiesUseCase getFacultiesUseCase,
            [FromServices] GetAllFacultiesPresenter getAllFacultiesPresenter)
        {
            await getFacultiesUseCase.Execute(new GetFacultiesInput());
            return getAllFacultiesPresenter.ViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> CreateFaculty(
            [FromServices] ICreateFacultyUseCase createFacultyUseCase,
            [FromServices] CreateFacultyPresenter createFacultyPresenter,
            [FromBody] CreateFacultyRequest input)
        {
            await createFacultyUseCase.Execute(new CreateFacultyInput(input.Title, input.Head, input.Subhead));
            return createFacultyPresenter.ViewModel;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFaculty(
            [FromServices] IUpdateFacultyUseCase updateFacultyUseCase,
            [FromServices] UpdateFacultyPresenter updateFacultyPresenter,
            [FromBody] Faculty input)
        {
            await updateFacultyUseCase.Execute(new UpdateFacultyInput(input));
            return updateFacultyPresenter.ViewModel;
        }


        [HttpDelete]
        public async Task<IActionResult> RemoveFaculty(
            [FromServices] IRemoveFacultyUseCase removeFacultyUseCase,
            [FromServices] RemoveFacultyPresenter removeFacultyPresenter,
            [FromBody] RequestId input)
        {
            await removeFacultyUseCase.Execute(new RemoveFacultyInput(input.Id));
            return removeFacultyPresenter.ViewModel;
        }
    }
}