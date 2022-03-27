using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validator;
using HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domain.LeaveRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handler.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (!validationResult.IsValid)
            {
                throw new Exception();
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            var response = await _leaveRequestRepository.Add(leaveRequest);
            return response.Id;
        }
    }
}
