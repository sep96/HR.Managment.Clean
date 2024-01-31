using HR.Managment.Application.Contracts.Identity;
using HR.Managment.Application.Model.Identity;
using HR.Managment.Clean.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Clean.Identity.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

        public async Task<Employee> GetEmployeeByID(string userId)
        {
            var employee = await _userManager.FindByIdAsync(userId);
            return new Employee
            {
                EmployeeID = employee.Id,
                EmployeeEmail = employee.Email,
                EmployeeFirstName = employee.FirstName,
                EmployeeLastName = employee.LastName
            };
        }


        public async Task<List<Employee>> GetEmployee()
        {
            var employees = await _userManager.GetUsersInRoleAsync("Employee");
            return employees.Select(q => new Employee
            {
                EmployeeID = q.Id,
                EmployeeEmail = q.Email,
                EmployeeFirstName = q.FirstName,
                EmployeeLastName = q.LastName
            }).ToList();
        }

    }
}
