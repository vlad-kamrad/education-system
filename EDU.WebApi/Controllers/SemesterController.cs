using EDU.Application.Boundaries.Department;
using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.Semester;
using EDU.Domain.Entities;
using EDU.WebApi.Presenters.Semester;
using EDU.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EDU.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SemesterController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllSemesters(
            [FromServices] IGetAllSemestersUseCase getAllSemestersUseCase,
            [FromServices] GetAllSemestersPresenter getAllSemestersPresenter)
        {
            await getAllSemestersUseCase.Execute(new GetAllSemestersInput());
            return getAllSemestersPresenter.ViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> GetSemesterInfo(
            [FromServices] IGetSemesterInfoUseCase getSemesterInfoUseCase,
            [FromServices] GetSemesterInfoPresenter getSemesterInfoPresenter,
            [FromBody] RequestId input)
        {
            await getSemesterInfoUseCase.Execute(new GetSemesterInfoInput(input.Id));
            return getSemesterInfoPresenter.ViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSemester(
            [FromServices] ICreateSemesterUseCase createSemesterUseCase,
            [FromServices] CreateSemesterPresenter createSemesterPresenter,
            [FromBody] CreateSemesterRequest input)
        {
            await createSemesterUseCase.Execute(new CreateSemesterInput(input.Start, input.End));
            return createSemesterPresenter.ViewModel;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSemester(
            [FromServices] IUpdateSemesterUseCase updateSemesterUseCase,
            [FromServices] UpdateSemesterPresenter updateSemesterPresenter,
            [FromBody] Semester input)
        {
            await updateSemesterUseCase.Execute(new UpdateSemesterInput(input));
            return updateSemesterPresenter.ViewModel;
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSemester(
            [FromServices] IRemoveSemesterUseCase removeSemesterUseCase,
            [FromServices] RemoveSemesterPresenter removeSemesterPresenter,
            [FromBody] RequestId input)
        {
            await removeSemesterUseCase.Execute(new RemoveSemesterInput(input.Id));
            return removeSemesterPresenter.ViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> AddExamToSemester()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEducationalCourse(
            [FromServices] ICreateEducationalCourseUseCase createEducationalCourseUseCase,
            [FromServices] CreateEducationalCoursePresenter createEducationalCoursePresenter,
            [FromBody] CreateEducationCourseRequest input)
        {
            await createEducationalCourseUseCase.Execute(new CreateEducationalCourseInput(input.Teacher, input.Description));
            return createEducationalCoursePresenter.ViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> AddExamResults()
        {
            throw new NotImplementedException();
        }
    }
}