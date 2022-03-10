using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto: BaseDomainDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateCreated { get; set; }
        public bool? Approved { get; set; }
    }
}
