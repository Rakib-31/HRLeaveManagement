using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.LeaveRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repository
{
    public class LeaveRequestRepository: GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly HrLeaveManagementDbContext _dbContext;
        public LeaveRequestRepository(HrLeaveManagementDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
        {
            return await _dbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            return await _dbContext.LeaveRequests
                .Include(x => x.LeaveType)
                .ToListAsync();
        }
    }
}
