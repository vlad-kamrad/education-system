using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.GetUser.GetFacultiesUseCase;
using EDU.Application.UseCases.Faculty;
using EDU.Domain.Repositories;
using EDU.WebApi.Presenters.Faculty;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EDU.Tests
{
    public class Faculty : IDisposable
    {
        public readonly IFacultyRepository facultyRepository;

        public Faculty()
        {
            facultyRepository = new Mock<IFacultyRepository>().Object;
        }

        [Fact]
        public async Task CreateFacultyUseCaseNullInput()
        {
            var output = new Mock<CreateFacultyPresenter>().Object;
            var useCase = new CreateFacultyUseCase(
                facultyRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task CreateFacultyUseCaseNotNullInput()
        {
            var output = new Mock<CreateFacultyPresenter>().Object;
            var useCase = new CreateFacultyUseCase(
                facultyRepository,
                output);
            await useCase.Execute(new CreateFacultyInput("", new Domain.Entities.User(), new Domain.Entities.User()));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task RemoveFacultyNullInput()
        {
            var output = new Mock<RemoveFacultyPresenter>().Object;
            var useCase = new RemoveFacultyUseCase(
                facultyRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task RemoveFacultyNotNullInput()
        {
            var output = new Mock<RemoveFacultyPresenter>().Object;
            var useCase = new RemoveFacultyUseCase(
                facultyRepository,
                output);
            await useCase.Execute(new RemoveFacultyInput(1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundResult);
        }

        [Fact]
        public async Task UpdateFacultyNullInput()
        {
            var output = new Mock<UpdateFacultyPresenter>().Object;
            var useCase = new UpdateFacultyUseCase(
                facultyRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task UpdateFacultyNotNullInput()
        {
            var output = new Mock<UpdateFacultyPresenter>().Object;
            var useCase = new UpdateFacultyUseCase(
                facultyRepository,
                output);
            await useCase.Execute(new UpdateFacultyInput(new Domain.Entities.Faculty()));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundResult);
        }

        [Fact]
        public async Task GetFacultiesUseCaseTest()
        {
            var output = new Mock<GetAllFacultiesPresenter>().Object;
            var useCase = new GetFacultiesUseCase(
                facultyRepository,
                output);
            await useCase.Execute(new GetFacultiesInput());

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        public void Dispose() { }
    }
}
