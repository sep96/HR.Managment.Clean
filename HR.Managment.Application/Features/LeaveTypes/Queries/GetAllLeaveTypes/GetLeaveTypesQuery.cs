using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    // record is imuutable , meaninh once  want defin it will pretty much nothing will change
    public record GetLeaveTypesQuery : IRequest<List<LeaveTypesDto>>;
}
