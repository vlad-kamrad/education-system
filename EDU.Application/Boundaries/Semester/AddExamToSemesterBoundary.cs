using EDU.Application.Boundaries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDU.Application.Boundaries.Semester
{
    public sealed class AddExamToSemesterInput { }
    public sealed class AddExamToSemesterOutput { }
    public interface IAddExamToSemesterOutputPort : IOutputPortStandard<AddExamToSemesterOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IAddExamToSemesterUseCase : IUseCase<AddExamToSemesterInput> { }
}
