using HR.LeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command
{
    public class CreateLeaveAllocationCommand: IRequest<int>
    {
        public LeaveAllocationDto LeaveAllocation { get; set; }
    }
}
