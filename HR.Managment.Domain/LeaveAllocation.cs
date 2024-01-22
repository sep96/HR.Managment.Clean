using HR.Managment.Domain.Common;

namespace HR.Managment.Domain
{
    public class LeaveAllocation : BaseEntity
    {
        public int LeaveAllocationID { get; set; }
        public int LeaveAllocationnumberOfDay { get; set; }
        public LeaveTypes? LeaveTypes { get; set; }
        public int LeaveTypesID { get; set; }
        public int LeaveAllocationPeriod { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
    }
}
