using HR.LeaveManagement.Domain.Common;
using HR.LeaveManagement.Domain.LeaveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Domain.LeaveAllocations
{
    public class LeaveAllocation: BaseDomainEntity
    {
        public int NumberOfDays { get; set; }
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
