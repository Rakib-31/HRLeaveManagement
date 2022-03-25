using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs
{
    public class LeaveTypeDto: BaseDomainDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
