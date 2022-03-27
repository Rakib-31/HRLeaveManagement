using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validator
{
    public class UpdateLeaveTypeDtoValidator: AbstractValidator<LeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new ILeaveTypeDtoValidator());
            RuleFor(x => x.Id)
                .NotNull().WithMessage("{PropertyName} must be present");
        }
    }
}
