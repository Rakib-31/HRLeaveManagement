using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Request.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.LeaveAllocations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handler.Command
{
    public class UpdateLeaveAllocationCommandHandler : IRequestHandler<UpdateLeaveAllocationCommand, Unit>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var leaveAllocation = await _leaveAllocationRepository.Get(request.UpdateLeaveAllocationDto.Id);
            if (leaveAllocation == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), request.UpdateLeaveAllocationDto.Id);
            }
            _mapper.Map(request.UpdateLeaveAllocationDto, leaveAllocation);
            await _leaveAllocationRepository.Update(leaveAllocation);
            return Unit.Value;
        }
    }
}
