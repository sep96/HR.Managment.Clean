using HR.Managment.Clean.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Clean.Identity.DbContext
{
    public class HrLeaveManagmentIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public HrLeaveManagmentIdentityDbContext(DbContextOptions<HrLeaveManagmentIdentityDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(HrLeaveManagmentIdentityDbContext).Assembly);
        }
    }
}
