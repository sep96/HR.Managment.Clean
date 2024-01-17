using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Domain;
using HR.Managment.Persistence.DatabaseContext;

namespace HR.Managment.Persistence.Repositories.LeaveType
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        protected readonly HrDatabaseContext _dBContext;
        public LeaveRequestRepository(HrDatabaseContext dBContext) : base(dBContext)
        {

        }
    }
}
