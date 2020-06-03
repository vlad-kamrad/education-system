using EDU.Application.Boundaries.User;
using EDU.WebApi.Presenters.User;
using EDU.WebApi.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDU.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> CreateUser(
            [FromServices] ICreateUserUseCase createUserUseCase,
            [FromServices] CreateUserPresenter createUserPresenter,
            [FromBody] CreateUserRequest input)
        {
            await createUserUseCase.Execute(new CreateUserInput(input.Username, input.Password, input.Email));
            return createUserPresenter.ViewModel;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(
            [FromServices] ILoginUseCase loginUseCase,
            [FromServices] LoginPresenter loginPresenter,
            [FromBody] LoginRequest input)
        {
            await loginUseCase.Execute(new LoginInput(input.Username, input.Password));
            return loginPresenter.ViewModel;
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(
            [FromServices] IChangePasswordUseCase changePasswordUseCase,
            [FromServices] ChangePasswordPresenter changePasswordPresenter,
            [FromBody] ChangePasswordRequest input)
        {
            await changePasswordUseCase.Execute(new ChangePasswordInput(input.Id, input.Password));
            return changePasswordPresenter.ViewModel;
        }

        [HttpPut]
        public async Task<IActionResult> ChangeRole(
            [FromServices] IChangeRoleUseCase changeRoleUseCase,
            [FromServices] ChangeRolePresenter changeRolePresenter,
            [FromBody] ChangeRoleRequest input)
        {
            await changeRoleUseCase.Execute(new ChangeRoleInput(input.UserId, input.RolesId));
            return changeRolePresenter.ViewModel;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(
            [FromServices] IGetAllUsersUseCase getAllUsersUseCase,
            [FromServices] GetAllUsersPresenter getAllUsersPresenter)
        {
            await getAllUsersUseCase.Execute(new GetAllUsersInput());
            return getAllUsersPresenter.ViewModel;
        }
    }
}