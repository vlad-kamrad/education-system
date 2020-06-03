using EDU.Application.Boundaries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDU.Application.Boundaries.Semester
{
    using Semester = EDU.Domain.Entities.Semester;
    public sealed class UpdateSemesterInput {
        public Semester UpdatedSemester { get; }
        public UpdateSemesterInput(Semester semester) => UpdatedSemester = semester;
    }
    public sealed class UpdateSemesterOutput {
        public bool Success { get; }
        public UpdateSemesterOutput(bool success) => Success = success;
    }
    public interface IUpdateSemesterOutputPort : IOutputPortStandard<UpdateSemesterOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IUpdateSemesterUseCase : IUseCase<UpdateSemesterInput> { }
}
