using EDU.Application;
using EDU.Application.Boundaries.User;
using EDU.Application.UseCases.Users;
using EDU.Domain.Users;
using EDU.WebApi.Presenters.User;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EDU.Tests
{
    public class UserTests : IDisposable
    {
        public readonly IUserRepository userRepository;
        public readonly IPasswordHasher passwordHasher;
        public readonly IAuthService authService;

        public UserTests()
        {
            userRepository = new Mock<IUserRepository>().Object;
            passwordHasher = new Mock<IPasswordHasher>().Object;
            authService = new Mock<IAuthService>().Object;
        }

        [Fact]
        public async Task CreateUserUseCaseNullInput()
        {
            var output = new Mock<CreateUserPresenter>().Object;
            var useCase = new CreateUserUseCase(
                userRepository,
                output,
                passwordHasher);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task CreateUserUseCaseNotNullInput()
        {
            var output = new Mock<CreateUserPresenter>().Object;
            var useCase = new CreateUserUseCase(
                userRepository,
                output,
                passwordHasher);
            await useCase.Execute(new CreateUserInput("", "", ""));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task ChangePasswordUseCaseNullInput()
        {
            var output = new Mock<ChangePasswordPresenter>().Object;
            var useCase = new ChangePasswordUseCase(
                userRepository,
                output,
                passwordHasher);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task ChangePasswordUseCaseNotNullInput()
        {
            var output = new Mock<ChangePasswordPresenter>().Object;
            var useCase = new ChangePasswordUseCase(
                userRepository,
                output,
                passwordHasher);
            await useCase.Execute(new ChangePasswordInput(1, ""));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundObjectResult);
        }

        [Fact]
        public async Task ChangeRoleUseCaseNullInput()
        {
            var output = new Mock<ChangeRolePresenter>().Object;
            var useCase = new ChangeRoleUseCase(
                userRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task ChangeRoleUseCaseNotNullInput()
        {
            var output = new Mock<ChangeRolePresenter>().Object;
            var useCase = new ChangeRoleUseCase(
                userRepository,
                output);
            await useCase.Execute(new ChangeRoleInput(1, new int[] { }));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundObjectResult);
        }

        [Fact]
        public async Task LoginUseCaseNullInput()
        {
            var output = new Mock<LoginPresenter>().Object;
            var useCase = new LoginUseCase(
                userRepository,
                output,
                authService);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task LoginUseCaseNotNullInput()
        {
            var output = new Mock<LoginPresenter>().Object;
            var useCase = new LoginUseCase(
                userRepository,
                output,
                authService);
            await useCase.Execute(new LoginInput("", ""));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundObjectResult);
        }

        public void Dispose() { }
    }
}
