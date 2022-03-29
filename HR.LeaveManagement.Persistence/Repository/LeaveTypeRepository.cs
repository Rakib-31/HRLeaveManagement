using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.LeaveTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Persistence.Repository
{
    public class LeaveTypeRepository: GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly HrLeaveManagementDbContext _dbContext;
        public LeaveTypeRepository(HrLeaveManagementDbContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
