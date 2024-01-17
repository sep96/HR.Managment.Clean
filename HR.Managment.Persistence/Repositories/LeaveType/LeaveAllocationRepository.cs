using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Domain;
using HR.Managment.Persistence.DatabaseContext;

namespace HR.Managment.Persistence.Repositories.LeaveType
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        protected readonly HrDatabaseContext _dBContext;
        public LeaveAllocationRepository(HrDatabaseContext dBContext) : base(dBContext)
        {

        }
    }
}
