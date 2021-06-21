using EDU.Application.Boundaries.GetUser;
using EDU.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDU.Application.UseCases.Groups
{
    public class GetAllGroupsUseCase : IGetAllGroupsUseCase
    {
        private readonly IGroupRepository groupRepository;
        private readonly IGetAllGroupsOutputPort outputPort;

        public GetAllGroupsUseCase(IGroupRepository groupRepository, IGetAllGroupsOutputPort outputPort)
        {
            this.groupRepository = groupRepository;
            this.outputPort = outputPort;
        }

        public async Task Execute(GetAllGroupsInput input)
        {
            var result = await groupRepository.Get();
            outputPort.Standart(new GetAllGroupsOutput(result));
        }
    }
}
