using EDU.Application.Boundaries.Department;
using EDU.Domain.Entities;
using EDU.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Semesters
{
    public class CreateEducationalCourseUseCase : ICreateEducationalCourseUseCase
    {
        private readonly ISemesterRepository semesterRepository;
        private readonly ICreateEducationalCourseOutputPort outputPort;

        public CreateEducationalCourseUseCase(ISemesterRepository semesterRepository, ICreateEducationalCourseOutputPort outputPort)
        {
            this.semesterRepository = semesterRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(CreateEducationalCourseInput input)
        {
            if (input == null) { outputPort.WriteError(""); return; }

            bool success = await semesterRepository.CreateEducationCourse(
                new EducationalCourse() { Description = input.Description, Teacher = input.Teacher });
            outputPort.Standart(new CreateEducationalCourseOutput(success));
        }
    }
}
