using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.Group;
using EDU.Domain.Entities;
using EDU.WebApi.Presenters.Group;
using EDU.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDU.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        [HttpGet("get")]
        public async Task<IActionResult> GetAllGroups(
            [FromServices] IGetAllGroupsUseCase getAllGroupsUseCase,
            [FromServices] GetAllGroupsPresenter getAllGroupsPresenter)
        {
            await getAllGroupsUseCase.Execute(new GetAllGroupsInput());
            return getAllGroupsPresenter.ViewModel;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateGroup(
            [FromServices] ICreateGroupUseCase createGroupUseCase,
            [FromServices] CreateGroupPresenter createGroupPresenter,
            [FromBody] CreateGroupRequest input)
        {
            await createGroupUseCase.Execute(new CreateGroupInput(input.Title, input.Curator, input.HeadMan));
            return createGroupPresenter.ViewModel;
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteGroup(
            [FromServices] IDeleteGroupUseCase deleteGroupUseCase,
            [FromServices] DeleteGroupPresenter deleteGroupPresenter,
            [FromBody] RequestId input)
        {
            await deleteGroupUseCase.Execute(new DeleteGroupInput(input.Id));
            return deleteGroupPresenter.ViewModel;
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateGroup(
            [FromServices] IUpdateGroupUseCase updateGroupUseCase,
            [FromServices] UpdateGroupPresenter updateGroupPresenter,
            [FromBody] Group input)
        {
            await updateGroupUseCase.Execute(new UpdateGroupInput(input));
            return updateGroupPresenter.ViewModel;
        }

        [HttpPost("add-student")]
        public async Task<IActionResult> AddStudent(
            [FromServices] IAddStudentUseCase addStudentUseCase,
            [FromServices] AddStudentPresenter addStudentPresenter,
            [FromBody] ChangeStudentRequest input)
        {
            await addStudentUseCase.Execute(new AddStudentInput(input.GroupId, input.StudentId));
            return addStudentPresenter.ViewModel;
        }

        [HttpDelete("remove-student")]
        public async Task<IActionResult> RemoveStudent(
            [FromServices] IRemoveStudentUseCase removeStudentUseCase,
            [FromServices] RemoveStudentPresenter removeStudentPresenter,
            [FromBody] ChangeStudentRequest input)
        {
            await removeStudentUseCase.Execute(new RemoveStudentInput(input.GroupId, input.StudentId));
            return removeStudentPresenter.ViewModel;
        }
    }
}