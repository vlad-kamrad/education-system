using EDU.Domain.Entities;
using System.Collections.Generic;

namespace EDU.Application.Boundaries.GetUser.GetFacultiesUseCase
{
    public class GetFacultiesOutput
    {
        public IList<Faculty> Faculties { get; }

        public GetFacultiesOutput(IList<Faculty> faculties) => Faculties = faculties;
    }
}
