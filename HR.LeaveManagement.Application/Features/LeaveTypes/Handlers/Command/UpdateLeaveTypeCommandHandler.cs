using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.LeaveTypes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Command
{
    public class UpdateLeaveTypeCommandHandler: IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateLeaveType);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var leaveType = await _leaveTypeRepository.Get(request.UpdateLeaveType.Id);
            if(leaveType == null)
            {
                throw new NotFoundException(nameof(LeaveType), request.UpdateLeaveType.Id);
            }
            _mapper.Map(request.UpdateLeaveType, leaveType);
            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;
        }
    }
}
