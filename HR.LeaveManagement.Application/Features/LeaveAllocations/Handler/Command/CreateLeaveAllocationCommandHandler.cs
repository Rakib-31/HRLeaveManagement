using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.LeaveAllocations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handler.Command
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocation);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocation);
            var response = await _leaveAllocationRepository.Add(leaveAllocation);
            return response.Id;
        }
    }
}
