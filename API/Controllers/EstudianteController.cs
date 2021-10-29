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
    public class EstudianteController : BaseApiController
    {
        private readonly IGenericRepository<Student> _attendeeRepo;
        private readonly IMapper _mapper;

        public EstudianteController(IGenericRepository<Student> attendeeRepo, IMapper mapper)
        {
            _attendeeRepo = attendeeRepo;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<StudentToReturnDto>>> GetAttendees([FromQuery] StudentSpecParams attendeeParams)
        {
            var spec = new StudentSpecification(attendeeParams);
            var countSpec = new StudentForCountSpecification(attendeeParams);
            var totalItems = await _attendeeRepo.CountAsync(countSpec);
            var attendees = await _attendeeRepo.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Student>, IReadOnlyList<StudentToReturnDto>>(attendees).ToList();
            return Ok(new Pagination<StudentToReturnDto>(attendeeParams.PageSize, attendeeParams.PageIndex, totalItems, data));
        }

        [HttpGet("{studentNumber}")]
        public async Task<ActionResult<ApiResponseOk>> GetStudendByNumber(string studentNumber)
        {
            var studentNumberFilterSpec = new StudentSpecification(studentNumber);
            var student = await _attendeeRepo.GetByIdAsync(studentNumberFilterSpec);
            var data = _mapper.Map<Student, StudentToReturnDto>(student);

            return data != null ? Ok(new ApiResponseOk(200, "Ok", data))
                                : BadRequest(new ApiResponse(404, "Studen Not Found"));

        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> RegisterAttendee([FromBody] StudentRegisterDto studentParam)
        {
            var studentFromParamsSpec = new StudentSpecification(studentParam.StudentNumber);
            var studentFromDb = await _attendeeRepo.GetByIdAsync(studentFromParamsSpec);
            int response = 0;
            //Si el estudianto no se encuentra en la base de datos se crea uno nuevo
            if (studentFromDb == null)
            {
                var newStudent = _mapper.Map<StudentRegisterDto, Student>(studentParam);
                newStudent.Activities = new List<Activity>();   
                newStudent.Activities.Add(new Activity
                {
                    Name = studentParam.Activity
                });

                response = await _attendeeRepo.SaveAsync(newStudent);

                return response > 0 ? new ApiResponse(200, "Estudiante Registrado con Éxito")
                                  : new ApiResponse(500, "Ocurrió un error");
            }
            
            //En caso de sí estar registrado agregamos la actividad a su lista de actividades ya registradas
            //Verificamos que no este registrado ya en esta actividad
            bool isAlreadyRegister = false;
            foreach (var activity in studentFromDb.Activities)
            {
                if (activity.Name.Equals(studentParam.Activity))
                {
                    isAlreadyRegister = true;
                }
            }

            if (!isAlreadyRegister)
            {
                studentFromDb.Activities.Add(new Activity
                {
                    Name = studentParam.Activity
                });

                response = await _attendeeRepo.UpdateEntityAsync(studentFromDb);

                return response > 0 ? new ApiResponse(200, "Estudiante Registrado con Éxito")
                                    : new ApiResponse(500, "Ocurrió un error");
            }

            return new ApiResponse(400, "Estudiante Ya se encuentra registrado");
        }
    }
}