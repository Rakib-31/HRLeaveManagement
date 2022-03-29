using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation
{
    public class ILeaveAllocationDtoValidator: AbstractValidator<ILeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public ILeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(x => x.NumberOfDays)
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be greater than {ComparisonValue}");

            RuleFor(x => x.Period)
                .GreaterThanOrEqualTo(DateTime.Now.Year)
                .WithMessage("{PropertyName} must be after {ComparisonValue}");

            RuleFor(x => x.LeaveTypeId)
                .MustAsync((id, token) =>
                {
                    return _leaveTypeRepository.Exists(id);
                }).WithMessage("{PropertyName} does not exists");
        }
    }
}
