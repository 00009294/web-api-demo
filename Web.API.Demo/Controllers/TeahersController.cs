
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Web.API.Demo.DbContexts;
using Web.API.Demo.Dto;
using Web.API.Demo.Interfaces;
using Web.API.Demo.Models;
using Web.API.Demo.Repositories;

namespace Web.API.Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        public IActionResult GetAllTeacher()
        {
            var teachers = _mapper.Map<List<TeacherDto>>(_teacherRepository.GetAllTeacher());
            if (ModelState.IsValid)
            {
                return Ok(teachers);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        public IActionResult GetTeacher(int id)
        {
            var teacher = _mapper.Map<TeacherDto>(_teacherRepository.GetTeacher(id));
            if (ModelState.IsValid)
            {
                return Ok(teacher);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        public IActionResult GetByName(string name)
        {
            var teacher = _mapper.Map<TeacherDto>(_teacherRepository.GetByName(name));
            if (ModelState.IsValid)
            {
                return Ok(teacher);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{isMale}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Teacher>))]
        public IActionResult GetByGender(bool isMale)
        {
            var teachers = _mapper.Map<List<Teacher>>(_teacherRepository.GetByGender(isMale).ToList());
            if (ModelState.IsValid)
            {
                return Ok(teachers);
            }
            return BadRequest(ModelState);
        }
    }
        
    
}
