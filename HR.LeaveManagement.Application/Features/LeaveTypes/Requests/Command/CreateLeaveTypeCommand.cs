using HR.LeaveManagement.Application.DTOs;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Command
{
    public class CreateLeaveTypeCommand: IRequest<int>
    {
        public LeaveTypeDto LeaveType { get; set; }
    }
}
