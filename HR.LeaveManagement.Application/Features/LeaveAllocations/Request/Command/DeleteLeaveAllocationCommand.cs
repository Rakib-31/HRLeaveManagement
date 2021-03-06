using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command
{
    public class DeleteLeaveAllocationCommand: IRequest
    {
        public int Id { get; set; }
    }
}
