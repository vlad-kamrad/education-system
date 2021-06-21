using EDU.Application.Boundaries.Department;
using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase;
using EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.GetAllDepartments;
using EDU.Application.Boundaries.GetUser.GetFacultiesUseCase;
using EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase;
using EDU.Application.Boundaries.GetUser.UpdateDepartmentUseCase;
using EDU.Application.Boundaries.Group;
using EDU.Application.Boundaries.Semester;
using EDU.Application.Boundaries.User;
using EDU.Application.UseCases.Departments;
using EDU.Application.UseCases.Faculty;
using EDU.Application.UseCases.Groups;
using EDU.Application.UseCases.Semesters;
using EDU.Application.UseCases.Users;
using Microsoft.Extensions.DependencyInjection;

namespace EDU.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            /// Departments Use Cases
            services.AddScoped<ICreateDepartmentUseCase, CreateDepartmentUseCase>();
            services.AddScoped<ICreateDisciplineUseCase, CreateDisciplineUseCase>();
            services.AddScoped<IDeleteDisciplineUseCase, DeleteDisciplineUseCase>();
            services.AddScoped<IGetAllDepartmentsUseCase, GetAllDepartmentsUseCase>();
            services.AddScoped<IRemoveDepartmentUseCase, RemoveDepartmentUseCase>();
            services.AddScoped<IUpdateDepartmentUseCase, UpdateDepartmentUseCase>();

            /// Faculty Use Cases
            services.AddScoped<ICreateFacultyUseCase, CreateFacultyUseCase>();
            services.AddScoped<IGetFacultiesUseCase, GetFacultiesUseCase>();
            services.AddScoped<IRemoveFacultyUseCase, RemoveFacultyUseCase>();
            services.AddScoped<IUpdateFacultyUseCase, UpdateFacultyUseCase>();

            /// Groups Use Cases
            services.AddScoped<IAddStudentUseCase, AddStudentUseCase>();
            services.AddScoped<ICreateGroupUseCase, CreateGroupUseCase>();
            services.AddScoped<IDeleteGroupUseCase, DeleteGroupUseCase>();
            services.AddScoped<IGetAllGroupsUseCase, GetAllGroupsUseCase>();
            services.AddScoped<IRemoveStudentUseCase, RemoveStudentUseCase>();
            services.AddScoped<IUpdateGroupUseCase, UpdateGroupUseCase>();

            /// Users Use Cases
            services.AddScoped<IChangePasswordUseCase, ChangePasswordUseCase>();
            services.AddScoped<IChangeRoleUseCase, ChangeRoleUseCase>();
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            services.AddScoped<IGetAllUsersUseCase, GetAllUsersUseCase>();
            services.AddScoped<ILoginUseCase, LoginUseCase>();

            /// Semesters Use Cases - Work In Progress
            services.AddScoped<ICreateSemesterUseCase, CreateSemesterUseCase>();
            services.AddScoped<ICreateEducationalCourseUseCase, CreateEducationalCourseUseCase>();
            services.AddScoped<ICreateSemesterUseCase, CreateSemesterUseCase>();
            services.AddScoped<IGetAllSemestersUseCase, GetAllSemestersUseCase>();
            services.AddScoped<IRemoveSemesterUseCase, RemoveSemesterUseCase>();
            services.AddScoped<IUpdateSemesterUseCase, UpdateSemesterUseCase>();

            return services;
        }
    }
}
