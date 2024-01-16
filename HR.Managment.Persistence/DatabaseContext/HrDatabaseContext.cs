using HR.Managment.Domain;
using HR.Managment.Domain.Common;
using HR.Managment.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Persistence.DatabaseContext
{
    public class HrDatabaseContext : DbContext
    {
        public HrDatabaseContext(DbContextOptions<HrDatabaseContext> options) : base(options)
        {

        }
        public DbSet<LeaveTypes> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HrDatabaseContext).Assembly);
            modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(x=>x.State.Equals(EntityState.Added) || x.State.Equals(EntityState.Modified)))
            {
                entry.Entity.ModifiedDateTime = DateTime.Now;
                if (entry.State.Equals(EntityState.Added))
                    entry.Entity.CreationDateTime = DateTime.Now;

            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
