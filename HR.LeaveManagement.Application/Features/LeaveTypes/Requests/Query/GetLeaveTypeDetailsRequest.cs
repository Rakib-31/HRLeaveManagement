using HR.LeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Query
{
    public class GetLeaveTypeDetailsRequest: IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
