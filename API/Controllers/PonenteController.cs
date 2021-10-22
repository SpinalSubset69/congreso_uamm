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
    public class PonenteController : BaseApiController
    {
        private readonly IGenericRepository<Rapportuer> __rappoRepo;
        private readonly IMapper __mapper;
        public PonenteController(IGenericRepository<Rapportuer> _rappoRepo, IMapper _mapper)
        {
            __mapper = _mapper;
            __rappoRepo = _rappoRepo;

        }

        [HttpGet]
        public async Task<ActionResult<ApiResponseOk>> GetRapportuers([FromQuery] RapportuerSpecParams specParams)
        {
            var spec = new RapportuerSpecifications(specParams);
            var rapportuers = await __rappoRepo.ListAsync(spec);
            var data = __mapper.Map<IReadOnlyList<Rapportuer>, IReadOnlyList<RapportuerToReturnDto>>(rapportuers);
            return Ok(new ApiResponseOk(200, "Ok", data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponseOk>> GetRapportuerById(int id){
            var spec = new RapportuerSpecifications(id);
            var rapportuer = await __rappoRepo.GetByIdAsync(spec);
            return rapportuer != null ? Ok(new ApiResponseOk(200, "Ok", rapportuer))
                                    : BadRequest(new ApiResponse(404, "Rapportuer Not Found"));
        }
    }
}