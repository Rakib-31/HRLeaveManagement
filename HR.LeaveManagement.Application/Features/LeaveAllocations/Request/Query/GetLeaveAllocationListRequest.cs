using HR.LeaveManagement.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Query
{
    public class GetLeaveAllocationListRequest: IRequest<List<LeaveAllocationDto>>
    {
    }
}
