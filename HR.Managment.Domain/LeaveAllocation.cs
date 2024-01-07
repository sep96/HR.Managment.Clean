namespace HR.Managment.Domain
{
    public class LeaveAllocation
    {
        public int LeaveAllocationID { get; set; }
        public int LeaveAllocationnumberOfDay { get; set; }
        public LeaveTypes? LeaveTypes { get; set; }
        public int LeaveTypesID { get; set; }
        public int LeaveAllocationPeriod { get; set; }
    }
}
