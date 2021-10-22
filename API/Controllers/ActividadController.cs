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
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ActividadController : BaseApiController
    {

        private readonly IMapper _mapper;
        private ActivityHelpers _helpers;
        private readonly IGenericRepository<Activity> _activityRepo;
        private readonly IGenericRepository<Rapportuer> _rapportuerRepo;

        public ActividadController(IGenericRepository<Activity> activityRepo,
                                   IGenericRepository<Rapportuer> rapportuerRepo,
                                   IMapper mapper)
        {
            _rapportuerRepo = rapportuerRepo;
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
            var data = _mapper.Map<IReadOnlyList<Activity>, IReadOnlyList<ActivityToReturnDto>>(activities).ToList();
            return Ok(new Pagination<ActivityToReturnDto>(activityParams.PageSize, activityParams.PageIndex, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActivityToReturnDto>> GetActivityById(int id)
        {
            var spec = new ActivitySpecifications(id);
            var activity = await _activityRepo.GetByIdAsync(spec);
            var data = _mapper.Map<Activity, ActivityToReturnDto>(activity);
            return data != null ? Ok(new ApiResponseOk(200, "Ok", data))
                                : BadRequest(new ApiResponse(404, "Activity Not Found"));
        }

        [HttpPost("agregarPonente")]
        public async Task<ActionResult<ApiResponseOk>> AddRapportuerToActivity([FromBody] RegisterRepportuerDto register)
        {
            _helpers = new ActivityHelpers();
            var spec = new ActivitySpecifications(register.ActivityId);
            var activity = await _activityRepo.GetByIdAsync(spec);            

            if (activity != null)
            {
                var rapportuer = _mapper.Map<RegisterRepportuerDto, Rapportuer>(register);

                //Verificar que el Ponente no exista en la base de datos, en caso de ser así, se almacena en la base de datos
                var rapportuerSpec = new RapportuerSpecifications(rapportuer.Name);
                var dbRapportuer = await _rapportuerRepo.GetByIdAsync(rapportuerSpec);

                //En caso de que exista en la base de datos verificamos si existe en la coleccion de ponentes de la actividad                
                //Verificamos que el ponento no exista en la actividad, en caso de ser así se agrega a la actividad
                if (!_helpers.RepportuerExistsOnActivity(activity.Rapportuers, dbRapportuer))
                {
                    activity.Rapportuers.Add(rapportuer);
                    var result = await _activityRepo.UpdateEntityAsync(activity);
                    return result > 0 ? Ok(new ApiResponse(200, "Rapportuer Added to Activity"))
                                        : BadRequest(new ApiResponse(500, "Failed"));
                }
                return BadRequest(new ApiResponse(500, "Rapportuer Already Exists on Activity"));
            }

            return BadRequest(new ApiResponse(404, "Activity Not Found"));
        }
    }
}