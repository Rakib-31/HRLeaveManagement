using AutoMapper;
using HR.LeaveManagement.Application.DTOs;
using HR.LeaveManagement.Application.Features.LeaveTypes.Requests.Query;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Query
{
    class GetLeaveTypeDetailsRequestHandler: IRequestHandler<GetLeaveTypeDetailsRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public GetLeaveTypeDetailsRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapping)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapping;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailsRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.Get(request.Id);
            return _mapper.Map<LeaveTypeDto>(leaveType);
        }
    }
}
