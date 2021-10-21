using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IGenericRepository<Activity> _activityRepo;

        public AttendeeController(IGenericRepository<Attendee> attendeeRepo, IGenericRepository<Activity> activityRepo, IMapper mapper)
        {
            _activityRepo = activityRepo;
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
            var data = _mapper.Map<IReadOnlyList<Attendee>, IReadOnlyList<AttendeeToReturnDto>>(attendees).ToList();
            return Ok(new Pagination<AttendeeToReturnDto>(attendeeParams.PageSize, attendeeParams.PageIndex, totalItems, data));
        }

        [HttpGet("{studentNumber}")]
        public async Task<ActionResult<ApiResponseOk>> GetStudendByNumber(string studentNumber){
            var studentNumberFilterSpec = new AttendeeSpecification(studentNumber);
            var student = await _attendeeRepo.GetByIdAsync(studentNumberFilterSpec);
            var data = _mapper.Map<Attendee, AttendeeToReturnDto>(student);

            return data != null ? Ok(new ApiResponseOk(200, "Ok", data))    
                                : BadRequest(new ApiResponse(404, "Studen Not Found"));
            
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> RegisterAttendee([FromBody] RegisterDto attendeeParam)
        {
            var newAttendee = _mapper.Map<RegisterDto, Attendee>(attendeeParam);
            var studentNumberFilterSpec = new AttendeeSpecification(attendeeParam.StudentNumber);
            var activityFilterSpec = new ActivitySpecifications(attendeeParam.ActivityId);

            var activity = await _activityRepo.GetByIdAsync(activityFilterSpec);
            var attendeeByStudentNumber = await _attendeeRepo.GetByIdAsync(studentNumberFilterSpec);

            if (attendeeByStudentNumber == null)
            {
                newAttendee.Activities = new List<Activity>();
                newAttendee.Activities.Add(activity);
                var attendee = await _attendeeRepo.SaveAsync(newAttendee);
                return attendee > 0 ? Ok(new ApiResponse(200, "Attendee Registered Succesfully"))
                                        :  BadRequest(new ApiException(400)); 
            }
            else
            {
                attendeeByStudentNumber.Name = attendeeParam.Name;
                attendeeByStudentNumber.Career =attendeeParam.Career;
                attendeeByStudentNumber.Email = attendeeParam.Email;
                attendeeByStudentNumber.RegisterAt = attendeeParam.RegisterAt;
                attendeeByStudentNumber.StudentNumber = attendeeParam.StudentNumber;
                if (!attendeeByStudentNumber.Activities.Contains(activity))
                {
                    attendeeByStudentNumber.Activities.Add(activity);
                    var result = await _attendeeRepo.UpdateEntityAsync(attendeeByStudentNumber);
                    return result > 0 ? Ok(new ApiResponse(200, "Attendee Registered Succesfully"))
                                        :  BadRequest(new ApiException(400));
                }
                return Ok(new ApiResponse(200, "Already Registered on this Activity"));
            }          
        }
    }
}