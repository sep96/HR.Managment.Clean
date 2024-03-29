﻿using HR.Managment.Application.Model.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployee();
        Task<Employee> GetEmployeeByID(string id);
    }
}
