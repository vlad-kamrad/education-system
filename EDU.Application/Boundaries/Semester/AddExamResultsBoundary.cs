using EDU.Application.Boundaries.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EDU.Application.Boundaries.Semester
{
    public sealed class AddExamResultsInput { }
    public sealed class AddExamResultsOutput { }
    public interface IAddExamResultsOutputPort : IOutputPortStandard<AddExamResultsOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface IAddExamResultsUseCase : IUseCase<AddExamResultsInput> { }
}
