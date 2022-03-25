using HR.LeaveManagement.Domain.LeaveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveTypeRepository: IGenericRepository<LeaveType>
    {
    }
}
