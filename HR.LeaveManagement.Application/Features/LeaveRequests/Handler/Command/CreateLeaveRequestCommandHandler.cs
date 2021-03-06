using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validator;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Request.Command;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain.LeaveRequests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Contracts.Infrastructure;
using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handler.Command
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly IMapper _mapper;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, 
            IMapper mapper, 
            ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            var response = await _leaveRequestRepository.Add(leaveRequest);

            var email = new Email
            {
                To = "",
                Subject = "New Email",
                Body = "Email test"
            };

            try
            {
                await _emailSender.EmailSend(email);
            }
            catch(Exception ex)
            {

            }

            return response.Id;
        }
    }
}
