using AutoMapper;
using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Application.Exceptions;
using HR.Managment.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Commands.DeleteLeaveType
{
    public class DeleteLeaveTypeCommandhandler : IRequestHandler<DeleteLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandhandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveTypetoDelete = await _leaveTypeRepository.GetByIDAsync(request.LeaveTypeID);
            if(leaveTypetoDelete is null ) 
                throw new NotFoundException(nameof(LeaveTypes) , request.LeaveTypeID);
            await _leaveTypeRepository.DeleteAsync(request.LeaveTypeID);
            return Unit.Value;
        }
    }
}
