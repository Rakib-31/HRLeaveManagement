﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto: BaseDomainDto
    {
        public bool? Approved { get; set; }
    }
}
