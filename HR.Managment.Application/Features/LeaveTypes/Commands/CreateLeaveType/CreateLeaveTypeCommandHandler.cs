using AutoMapper;
using HR.Managment.Application.Contracts.Logging;
using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, int>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CreateLeaveTypeCommand> _log;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper , IAppLogger<CreateLeaveTypeCommand> log)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
            _log = log;
        }

        public async Task<int> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveTypeCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.Errors.Any())
            {
                _log.LogInformation("Validation Failed {0} , {1}", nameof(LeaveTypes), 0);
                throw new BadRequestException("Validation Failed", validationResult);
            }
            var leaveTypeToCreate = _mapper.Map<Domain.LeaveTypes>(request);
            var result = await _leaveTypeRepository.AddAsync(leaveTypeToCreate);
            return result.LeaveTypesID;
        }
    }
}
