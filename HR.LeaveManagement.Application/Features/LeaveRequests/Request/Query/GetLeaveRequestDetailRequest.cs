using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Request.Query
{
    public class GetLeaveRequestDetailRequest: IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
