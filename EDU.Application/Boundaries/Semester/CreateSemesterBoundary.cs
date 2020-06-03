using EDU.Application.Boundaries.Interfaces;
using System;

namespace EDU.Application.Boundaries.GetUser
{
    public sealed class CreateSemesterInput
    {
        public DateTime Start { get; }
        public DateTime End { get; }
        public CreateSemesterInput(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
    public sealed class CreateSemesterOutput
    {
        public bool Success { get; }
        public CreateSemesterOutput(bool success) => Success = success;
    }
    public interface ICreateSemesterOutputPort : IOutputPortStandard<CreateSemesterOutput>, IOutputPortError, IOutputPortNotFound { }
    public interface ICreateSemesterUseCase : IUseCase<CreateSemesterInput> { }
}
