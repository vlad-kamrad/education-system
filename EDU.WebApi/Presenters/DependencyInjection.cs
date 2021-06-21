using EDU.Application.Boundaries.Department;
using EDU.Application.Boundaries.Department.UpdateDepartmentUseCase;
using EDU.Application.Boundaries.GetUser;
using EDU.Application.Boundaries.GetUser.CreateDepartmentUseCase;
using EDU.Application.Boundaries.GetUser.CreateDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.DeleteDisciplineUseCase;
using EDU.Application.Boundaries.GetUser.GetAllDepartments;
using EDU.Application.Boundaries.GetUser.GetFacultiesUseCase;
using EDU.Application.Boundaries.GetUser.RemoveDepartmentUseCase;
using EDU.Application.Boundaries.Group;
using EDU.Application.Boundaries.Semester;
using EDU.Application.Boundaries.User;
using EDU.WebApi.Presenters.Department;
using EDU.WebApi.Presenters.Faculty;
using EDU.WebApi.Presenters.Group;
using EDU.WebApi.Presenters.Semester;
using EDU.WebApi.Presenters.User;
using Microsoft.Extensions.DependencyInjection;

namespace EDU.WebApi.Presenters
{
    internal static class DependencyInjection
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            /// Department
            services.AddScoped<GetAllDepartmentsPresenter>();
            services.AddScoped<IGetAllDepartmentsOutputPort>(x => x.GetRequiredService<GetAllDepartmentsPresenter>());
            services.AddScoped<CreateDepartmentPresenter>();
            services.AddScoped<ICreateDepartmentOutputPort>(x => x.GetRequiredService<CreateDepartmentPresenter>());
            services.AddScoped<UpdateDepartmentPresenter>();
            services.AddScoped<IUpdateDepartmentOutputPort>(x => x.GetRequiredService<UpdateDepartmentPresenter>());
            services.AddScoped<RemoveDepartmentPresenter>();
            services.AddScoped<IRemoveDepartmentOutputPort>(x => x.GetRequiredService<RemoveDepartmentPresenter>());
            services.AddScoped<CreateDisciplinePresenter>();
            services.AddScoped<ICreateDisciplineOutputPort>(x => x.GetRequiredService<CreateDisciplinePresenter>());
            services.AddScoped<DeleteDisciplinePresenter>();
            services.AddScoped<IDeleteDisciplineOutputPort>(x => x.GetRequiredService<DeleteDisciplinePresenter>());

            /// Faculties
            services.AddScoped<GetAllFacultiesPresenter>();
            services.AddScoped<IGetFacultiesOutputPort>(x => x.GetRequiredService<GetAllFacultiesPresenter>());
            services.AddScoped<CreateFacultyPresenter>();
            services.AddScoped<ICreateFacultyOutputPort>(x => x.GetRequiredService<CreateFacultyPresenter>());
            services.AddScoped<UpdateFacultyPresenter>();
            services.AddScoped<IUpdateFacultyOutputPort>(x => x.GetRequiredService<UpdateFacultyPresenter>());
            services.AddScoped<RemoveFacultyPresenter>();
            services.AddScoped<IRemoveFacultyOutputPort>(x => x.GetRequiredService<RemoveFacultyPresenter>());

            /// Groups
            services.AddScoped<GetAllGroupsPresenter>();
            services.AddScoped<IGetAllGroupsOutputPort>(x => x.GetRequiredService<GetAllGroupsPresenter>());
            services.AddScoped<CreateGroupPresenter>();
            services.AddScoped<ICreateGroupOutputPort>(x => x.GetRequiredService<CreateGroupPresenter>());
            services.AddScoped<DeleteGroupPresenter>();
            services.AddScoped<IDeleteGroupOutputPort>(x => x.GetRequiredService<DeleteGroupPresenter>());
            services.AddScoped<UpdateGroupPresenter>();
            services.AddScoped<IUpdateGroupOutputPort>(x => x.GetRequiredService<UpdateGroupPresenter>());
            services.AddScoped<AddStudentPresenter>();
            services.AddScoped<IAddStudentOutputPort>(x => x.GetRequiredService<AddStudentPresenter>());
            services.AddScoped<RemoveStudentPresenter>();
            services.AddScoped<IRemoveStudentOutputPort>(x => x.GetRequiredService<RemoveStudentPresenter>());

            /// Semesters
            services.AddScoped<GetAllSemestersPresenter>();
            services.AddScoped<IGetAllSemestersOutputPort>(x => x.GetRequiredService<GetAllSemestersPresenter>());
            services.AddScoped<GetSemesterInfoPresenter>();
            services.AddScoped<IGetSemesterInfoOutputPort>(x => x.GetRequiredService<GetSemesterInfoPresenter>());
            services.AddScoped<CreateSemesterPresenter>();
            services.AddScoped<ICreateSemesterOutputPort>(x => x.GetRequiredService<CreateSemesterPresenter>());
            services.AddScoped<UpdateSemesterPresenter>();
            services.AddScoped<IUpdateSemesterOutputPort>(x => x.GetRequiredService<UpdateSemesterPresenter>());
            services.AddScoped<RemoveSemesterPresenter>();
            services.AddScoped<IRemoveSemesterOutputPort>(x => x.GetRequiredService<RemoveSemesterPresenter>());
            services.AddScoped<CreateEducationalCoursePresenter>();
            services.AddScoped<ICreateEducationalCourseOutputPort>(x => x.GetRequiredService<CreateEducationalCoursePresenter>());

            /// Users
            services.AddScoped<CreateUserPresenter>();
            services.AddScoped<ICreateUserOutputPort>(x => x.GetRequiredService<CreateUserPresenter>());
            services.AddScoped<LoginPresenter>();
            services.AddScoped<ILoginOutputPort>(x => x.GetRequiredService<LoginPresenter>());
            services.AddScoped<ChangePasswordPresenter>();
            services.AddScoped<IChangePasswordOutputPort>(x => x.GetRequiredService<ChangePasswordPresenter>());
            services.AddScoped<ChangeRolePresenter>();
            services.AddScoped<IChangeRoleOutputPort>(x => x.GetRequiredService<ChangeRolePresenter>());
            services.AddScoped<GetAllUsersPresenter>();
            services.AddScoped<IGetAllUsersOutputPort>(x => x.GetRequiredService<GetAllUsersPresenter>());

            return services;
        }
    }
}
