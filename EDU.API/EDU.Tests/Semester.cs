using EDU.Application.Boundaries.Department;
using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.Semester;
using EDU.Application.UseCases.Semesters;
using EDU.Domain.Repositories;
using EDU.WebApi.Presenters.Semester;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EDU.Tests
{
    public class Semester : IDisposable
    {
        private readonly ISemesterRepository semesterRepository;

        public Semester()
        {
            semesterRepository = new Mock<ISemesterRepository>().Object;
        }

        [Fact]
        public async Task CreateGroupUseCaseNullInput()
        {
            var output = new Mock<CreateSemesterPresenter>().Object;
            var useCase = new CreateSemesterUseCase(
                semesterRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task CreateGroupUseCaseNotNullInput()
        {
            var output = new Mock<CreateSemesterPresenter>().Object;
            var useCase = new CreateSemesterUseCase(
                semesterRepository,
                output);
            await useCase.Execute(new CreateSemesterInput(DateTime.Now.AddDays(-100), DateTime.Now));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task CreateEducationalCourseUseCaseNullInput()
        {
            var output = new Mock<CreateEducationalCoursePresenter>().Object;
            var useCase = new CreateEducationalCourseUseCase(
                semesterRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task CreateEducationalCourseUseCaseNotNullInput()
        {
            var output = new Mock<CreateEducationalCoursePresenter>().Object;
            var useCase = new CreateEducationalCourseUseCase(
                semesterRepository,
                output);
            await useCase.Execute(new CreateEducationalCourseInput(new Domain.Entities.User(), ""));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }


        [Fact]
        public async Task RemoveSemesterUseCaseNullInput()
        {
            var output = new Mock<RemoveSemesterPresenter>().Object;
            var useCase = new RemoveSemesterUseCase(
                semesterRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task RemoveSemesterUseCaseNotNullInput()
        {
            var output = new Mock<RemoveSemesterPresenter>().Object;
            var useCase = new RemoveSemesterUseCase(
                semesterRepository,
                output);
            await useCase.Execute(new RemoveSemesterInput(1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task UpdateSemesterUseCaseNullInput()
        {
            var output = new Mock<UpdateSemesterPresenter>().Object;
            var useCase = new UpdateSemesterUseCase(
                semesterRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task UpdateSemesterUseCaseNotNullInput()
        {
            var output = new Mock<RemoveSemesterPresenter>().Object;
            var useCase = new RemoveSemesterUseCase(
                semesterRepository,
                output);
            await useCase.Execute(new RemoveSemesterInput(1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task GetAllSemestersUseCaseTest()
        {
            var output = new Mock<GetAllSemestersPresenter>().Object;
            var useCase = new GetAllSemestersUseCase(
                semesterRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task GetSemesterInfoUseCase()
        {
            var output = new Mock<GetSemesterInfoPresenter>().Object;
            var useCase = new GetSemesterInfoUseCase(
                semesterRepository,
                output);
            await useCase.Execute(new GetSemesterInfoInput(1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        public void Dispose() { }
    }
}
