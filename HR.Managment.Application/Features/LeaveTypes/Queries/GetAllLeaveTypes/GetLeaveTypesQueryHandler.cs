using AutoMapper;
using HR.Managment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public class GetLeaveTypesQueryhandler : IRequestHandler<GetLeaveTypesQuery, List<LeaveTypesDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypesQueryhandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<List<LeaveTypesDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
        {
            //Query DataBase 
            var leaveTypes = await _leaveTypeRepository.GetAllAsync();
            return _mapper.Map<List<LeaveTypesDto>>(leaveTypes);    
        }
    }
}
