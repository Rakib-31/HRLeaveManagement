using HR.LeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Command
{
    public class UpdateLeaveTypeCommand: IRequest<Unit>
    {
        public LeaveTypeDto UpdateLeaveType { get; set; }
    }
}
