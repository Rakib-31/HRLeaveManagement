using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validator
{
    public class CreateLeaveRequestDtoValidator: AbstractValidator<CreateLeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTyeRepository;
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTyeRepository)
        {
            _leaveTyeRepository = leaveTyeRepository;
            Include(new ILeaveRequestDtoValidator(_leaveTyeRepository));
        }
    }
}
