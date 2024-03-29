﻿using HR.Managment.Domain;

namespace HR.Managment.Application.Contracts.Persistence
{
    public interface ILeaveTypeRepository: IGenericRepository<LeaveTypes>
    {
        Task<bool> IsLeaveTypeUnique(string name);
    } 
}
