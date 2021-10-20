using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Errors;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AttendeeController : BaseApiController
    {
        private readonly IGenericRepository<Attendee> _attendeeRepo;
        private readonly IMapper _mapper;

        public AttendeeController(IGenericRepository<Attendee> attendeeRepo, IMapper mapper)
        {
            _attendeeRepo = attendeeRepo;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<AttendeeToReturnDto>>> GetAttendees([FromQuery] AttendeeSpecParams attendeeParams)
        {
            var spec = new AttendeeSpecification(attendeeParams);
            var countSpec = new AttendeeForCountSpecification(attendeeParams);
            var totalItems = await _attendeeRepo.CountAsync(countSpec);
            var attendees = await _attendeeRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Attendee>, IReadOnlyList<AttendeeToReturnDto>>(attendees);            
            return Ok(new Pagination<AttendeeToReturnDto>(attendeeParams.PageSize, attendeeParams.PageIndex, totalItems, data));
        }
        [HttpPost]
        public async Task<ActionResult<ApiResponse>>RegisterAttendee([FromBody]RegisterDto attendeeParam){                
                var attendeeToReturn = _mapper.Map<RegisterDto, Attendee>(attendeeParam);
                var attendee = await _attendeeRepo.SaveAsync(attendeeToReturn);
                if(attendee > 0)                {
                    return Ok(new ApiResponse(200));
                }                
                return BadRequest(new ApiException(400));
        }
    }
}