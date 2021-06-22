using EDU.Application.Boundaries.Department;
using EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase;
using EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase;
using EDU.Application.UseCases.Departments;
using EDU.Domain.Repositories;
using EDU.WebApi.Presenters;
using EDU.WebApi.Presenters.Department;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EDU.Tests
{
    public class Departments : IDisposable
    {
        public CreateDepartmentPresenter createDepartmentOutputPort;
        public IDepartmentRepository departmentRepository;
        public CreateDepartmentUseCase createDepartmentUseCase;

        public Departments()
        {
            departmentRepository = new Mock<IDepartmentRepository>().Object;
        }

        [Fact]
        public async Task CreateDepartmentUseCaseNullInput()
        {
            var output = new Mock<CreateDepartmentPresenter>().Object;
            var useCase = new CreateDepartmentUseCase(
                output,
                departmentRepository);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task CreateDepartmentUseCaseNotNullInput()
        {
            var output = new Mock<CreateDepartmentPresenter>().Object;
            var useCase = new CreateDepartmentUseCase(
                output,
                departmentRepository);
            await useCase.Execute(new CreateDepartmentInput("", 1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task CreateDisciplineUseCaseNullInput()
        {
            var output = new Mock<CreateDisciplinePresenter>().Object;
            var useCase = new CreateDisciplineUseCase(
                departmentRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task CreateDisciplineUseCaseNotNullInput()
        {
            var output = new Mock<CreateDisciplinePresenter>().Object;
            var useCase = new CreateDisciplineUseCase(
                departmentRepository,
                output);
            await useCase.Execute(new CreateDisciplineInput(1, "", ""));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task DeleteDisciplineUseCaseNullInput()
        {
            var output = new Mock<DeleteDisciplinePresenter>().Object;
            var useCase = new DeleteDisciplineUseCase(
                departmentRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task DeleteDisciplineUseCaseNotNullInput()
        {
            var output = new Mock<DeleteDisciplinePresenter>().Object;
            var useCase = new DeleteDisciplineUseCase(
                departmentRepository,
                output);
            await useCase.Execute(new DeleteDisciplineInput(1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task GetAllDepartmentsUseCase()
        {
            var output = new Mock<GetAllDepartmentsPresenter>().Object;
            var useCase = new GetAllDepartmentsUseCase(
                departmentRepository,
                output);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is OkObjectResult);
        }

        [Fact]
        public async Task RemoveDepartmentUseCaseNullInput()
        {
            var output = new Mock<RemoveDepartmentPresenter>().Object;
            var useCase = new RemoveDepartmentUseCase(
                output,
                departmentRepository);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task RemoveDepartmentUseCaseNotNullInput()
        {
            var output = new Mock<RemoveDepartmentPresenter>().Object;
            var useCase = new RemoveDepartmentUseCase(
                output,
                departmentRepository);
            await useCase.Execute(new RemoveDepartmentInput(1));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundResult);
        }

        [Fact]
        public async Task UpdateDepartmentNullInput()
        {
            var output = new Mock<UpdateDepartmentPresenter>().Object;
            var useCase = new UpdateDepartmentUseCase(
                output,
                departmentRepository);
            await useCase.Execute(null);

            Assert.NotNull(output);
            Assert.True(output.ViewModel is BadRequestObjectResult);
        }

        [Fact]
        public async Task UpdateDepartmentNotNullInput()
        {
            var output = new Mock<UpdateDepartmentPresenter>().Object;
            var useCase = new UpdateDepartmentUseCase(
                output,
                departmentRepository);
            await useCase.Execute(new UpdateDepartmentInput(new Domain.Entities.Department()));

            Assert.NotNull(output);
            Assert.True(output.ViewModel is NotFoundResult);
        }

        public void Dispose() { }
    }
}
