﻿using HR.LeaveManagement.Domain.LeaveAllocations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Configurations.Entities
{
    public class LeaveAllocationConfiguration : IEntityTypeConfiguration<LeaveAllocation>
    {
        public void Configure(EntityTypeBuilder<LeaveAllocation> builder)
        {
            //builder.HasData(
            //    new LeaveType
            //    {
            //        Id = 1,
            //        DefaultDays = 10,
            //        Name = "Vacation"
            //    },
            //     new LeaveType
            //     {
            //         Id = 2,
            //         DefaultDays = 12,
            //         Name = "Sick"
            //     }
            //);
        }
    }
}
