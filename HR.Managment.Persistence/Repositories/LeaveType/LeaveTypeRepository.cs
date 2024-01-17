using HR.Managment.Application.Contracts.Persistence;
using HR.Managment.Domain;
using HR.Managment.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Persistence.Repositories.LeaveType
{
    public class LeaveTypeRepository : GenericRepository<LeaveTypes>, ILeaveTypeRepository
    {
        protected readonly HrDatabaseContext _dBContext;
        public LeaveTypeRepository(HrDatabaseContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<bool> IsLeaveTypeUnique(string name)
        {
            return await _dBContext.LeaveTypes.AnyAsync(x => x.LeaveTypesName.Equals(name));
        }
    }
}
