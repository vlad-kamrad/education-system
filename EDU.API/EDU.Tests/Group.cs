using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.Group;
using EDU.Application.UseCases.Groups;
using EDU.Domain.Repositories;
using EDU.Domain.Users;
using EDU.WebApi.Presenters.Group;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EDU.Tests
{
    public class Group : IDisposable
    {
        public readonly IGroupRepository groupRepository;
        public readonly IUserRepository userRepository;
        public Group()
        {
            groupRepository = new Mock<IGroupRepository>().Object;
            userRepository = new Mock<IUserRepository>().Object;
        }

        [Fact]
        public async Task CreateGroupUseCaseNullInput()
        {
            var output = new Mock<CreateGroupPresenter>().Object;
            var useCase = new CreateGroupUseCase(
                groupRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task CreateGroupUseCaseNotNullInput()
        {
            var output = new Mock<CreateGroupPresenter>().Object;
            var useCase = new CreateGroupUseCase(
                groupRepository,
                output);
            await useCase.Execute(new CreateGroupInput("", new Domain.Entities.User(), new Domain.Entities.User()));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task AddStudentUseCaseNullInput()
        {
            var output = new Mock<AddStudentPresenter>().Object;
            var useCase = new AddStudentUseCase(
                groupRepository,
                userRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task AddStudentUseCaseNotNullInput()
        {
            var output = new Mock<AddStudentPresenter>().Object;
            var useCase = new AddStudentUseCase(
                groupRepository,
                userRepository,
                output);
            await useCase.Execute(new AddStudentInput(1, 1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundObjectResult);
        }

        [Fact]
        public async Task DeleteGroupUseCaseNullInput()
        {
            var output = new Mock<DeleteGroupPresenter>().Object;
            var useCase = new DeleteGroupUseCase(
                groupRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task DeleteGroupUseCaseNotNullInput()
        {
            var output = new Mock<DeleteGroupPresenter>().Object;
            var useCase = new DeleteGroupUseCase(
                groupRepository,
                output);
            await useCase.Execute(new DeleteGroupInput(1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundObjectResult);
        }

        [Fact]
        public async Task RemoveStudentUseCaseNullInput()
        {
            var output = new Mock<RemoveStudentPresenter>().Object;
            var useCase = new RemoveStudentUseCase(
                groupRepository,
                output,
                userRepository);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task RemoveStudentUseCaseNotNullInput()
        {
            var output = new Mock<RemoveStudentPresenter>().Object;
            var useCase = new RemoveStudentUseCase(
                 groupRepository,
                 output,
                 userRepository);
            await useCase.Execute(new RemoveStudentInput(1, 1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundObjectResult);
        }

        [Fact]
        public async Task UpdateGroupUseCaseNullInput()
        {
            var output = new Mock<UpdateGroupPresenter>().Object;
            var useCase = new UpdateGroupUseCase(
                groupRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task UpdateGroupUseCaseNotNullInput()
        {
            var output = new Mock<UpdateGroupPresenter>().Object;
            var useCase = new UpdateGroupUseCase(
                groupRepository,
                output);
            await useCase.Execute(new UpdateGroupInput(new Domain.Entities.Group()));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundObjectResult);
        }

        [Fact]
        public async Task GetAllGroupsUseCaseTest()
        {
            var output = new Mock<GetAllGroupsPresenter>().Object;
            var useCase = new GetAllGroupsUseCase(
                groupRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        public void Dispose() { }
    }
}
