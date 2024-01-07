using HR.Managment.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails
{
    public record GetLeaveTypeDetailsQuery(int id) : IRequest<LeaveTypeDetailsDto>;
}
