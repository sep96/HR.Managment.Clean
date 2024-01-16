using HR.Managment.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HR.Managment.Persistence.Configurations
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveTypes>
    {
        public void Configure(EntityTypeBuilder<LeaveTypes> builder)
        {
            builder.HasData(
                new LeaveTypes
                {
                    LeaveTypesID = 1,
                    LeaveTypesName = "Vacation",
                    LeaveTypesDefaultDays = 1,
                    CreationDateTime = DateTime.Now,
                    ModifiedDateTime = DateTime.Now
                });
        }

    }
}
