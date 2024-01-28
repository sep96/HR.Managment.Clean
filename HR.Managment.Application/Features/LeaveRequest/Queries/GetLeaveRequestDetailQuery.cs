using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveRequest.Queries
{
    public class GetLeaveRequestDetailQuery : IRequest<LeaveRequestDetailsDto>
    {
        public int Id { get; set; }
    }
}
