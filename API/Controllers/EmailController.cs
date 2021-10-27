using API.Dtos;
using API.Errors;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class EmailController : BaseApiController
    {
        private readonly IEmailService _emailService = null;
        private readonly IMapper _mapper;
        public EmailController(IEmailService emailService, IMapper mapper)
        {
            _mapper = mapper;
            _emailService = emailService;

        }
      
        [HttpPost]
        public ActionResult<ApiResponse> SendEmailFromStudent([FromBody] EmailUserDataDto userData)
        {
            var data = _mapper.Map<EmailUserDataDto, EmailUserData>(userData);
             var sendEmail = _emailService.EmailFromUsers(data);
            return sendEmail.Contains("Success") ? Ok(new ApiResponse(200, "Mensaje Enviado"))
                                                    : BadRequest(new ApiResponse(400, sendEmail));
        }
    }
}