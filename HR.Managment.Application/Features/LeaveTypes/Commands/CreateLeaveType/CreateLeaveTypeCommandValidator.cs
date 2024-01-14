using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Commands.CreateLeaveType
{
    public class CreateLeaveTypeCommandValidator:
        AbstractValidator <CreateLeaveTypeCommand>
    {
        public CreateLeaveTypeCommandValidator()
        {
            RuleFor(p => p.LeaveTypesName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(70).WithMessage("{PropertyName} Muste be Fewer than 70");
            RuleFor(p => p.LeaveTypesDefaultDays)
                .GreaterThan(50).WithMessage("{PropertyName} Can not be morethan 50")
                .LessThan(1).WithMessage("{PropertyName} Can not be less than  1");
        }
    }
}
