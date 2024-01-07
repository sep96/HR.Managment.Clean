namespace HR.Managment.Domain
{
    public class LeaveRequest
    {
        public int LeaveRequestID { get; set; }
        public DateTime LeaveRequestStartDate { get; set; }
        public DateTime LeaveRequestEndDate { get; set; }
        public LeaveTypes? LeaveTypes { get; set; }
        public int LeaveTypesID { get; set; }
        public DateTime LeaveRequestDateRequested { get; set; }
        public string? LeaveRequestRequestComments { get; set; }
        public bool? LeaveRequestApproved { get; set; }
        public bool LeaveRequestCancelled { get; set; }
    }
}
