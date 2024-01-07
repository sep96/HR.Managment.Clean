using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes
{
    public class LeaveTypesDto
    {
        public int LeaveTypesID { get; set; }
        public string LeaveTypesName { get; set; } = string.Empty;
        public int LeaveTypesDefaultDays { get; set; }
    }
}
