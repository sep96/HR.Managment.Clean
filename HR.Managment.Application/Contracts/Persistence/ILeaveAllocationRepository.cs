using HR.Managment.Domain;

namespace HR.Managment.Application.Contracts.Persistence
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        Task<LeaveRequest> GetLeaveRequestByIDAsync(int id );   
        Task<List<LeaveRequest>> GetLeaveRequestListAsync();   
        Task<List<LeaveRequest>> GetLeaveRequestListByuserNameAsync(int userId);
        Task<bool> AllocationExists(string userId, int leaveTypeId, int period);
        Task AddAllocations(List<LeaveAllocation> allocations);
        Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId);


    }
}
