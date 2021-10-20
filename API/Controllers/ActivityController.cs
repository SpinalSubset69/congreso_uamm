using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActivityController : BaseApiController
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Activity> _activityRepo;

        public ActivityController(IGenericRepository<Activity> activityRepo, IMapper mapper)
        {
            _activityRepo = activityRepo;

            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<Pagination<ActivityToReturnDto>>> GetActivities([FromQuery] ActivitySpecParams activityParams)
        {
            var spec = new ActivitySpecifications(activityParams);
            var countSpec = new ActivityForCountSpecification(activityParams);
            var totalItems = await _activityRepo.CountAsync(countSpec);
            var activities = await _activityRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Activity>, IReadOnlyList<ActivityToReturnDto>>(activities);

            return Ok(new Pagination<ActivityToReturnDto>(activityParams.PageSize, activityParams.PageIndex, totalItems, data));
        }
    }
}