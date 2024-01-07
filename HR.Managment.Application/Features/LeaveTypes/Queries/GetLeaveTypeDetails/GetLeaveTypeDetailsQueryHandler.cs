using AutoMapper;
using HR.Managment.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryhandler : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeDetailsQueryhandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var LeaveTypeDetail = await _leaveTypeRepository.GetByIDAsync(request.id);
            return _mapper.Map<LeaveTypeDetailsDto>(LeaveTypeDetail);
        }
    }
}
