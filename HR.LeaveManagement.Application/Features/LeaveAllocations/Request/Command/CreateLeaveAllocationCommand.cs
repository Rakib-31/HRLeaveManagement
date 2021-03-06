using HR.LeaveManagement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command
{
    public class CreateLeaveAllocationCommand: IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocation { get; set; }
    }
}
