using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Domain;
using HR.Managment.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.Managment.Persistence.Repositories.LeaveType
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        protected readonly HrDatabaseContext _dBContext;
        public LeaveAllocationRepository(HrDatabaseContext dBContext) : base(dBContext)
        {

        }

        public async Task AddAllocations(List<LeaveAllocation> allocations)
        {
            await _context.AddRangeAsync(allocations);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
        {
            return await _dBContext.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                        && q.LeaveTypesID == leaveTypeId
                                        && q.LeaveAllocationPeriod == period);
        }


        public async Task<LeaveRequest> GetLeaveRequestByIDAsync(int id)
        {
            return await _dBContext.LeaveRequests.Include(x => x.LeaveTypes).FirstOrDefaultAsync(x => x.LeaveRequestID.Equals(id));
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestListAsync()
        {
            return await _dBContext.LeaveRequests.Include(x => x.LeaveTypes).ToListAsync();
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestListByuserNameAsync(int userID)
        {
            return await _dBContext.LeaveRequests.Where(x=>x.CreateionUserID.Equals(userID)).Include(x => x.LeaveTypes).ToListAsync();
        }


        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
        {
            return await _dBContext.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                        && q.LeaveTypesID == leaveTypeId);
        }
    }
}
