
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
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository teacherRepository,ISubjectRepository subjectRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _subjectRepository = subjectRepository;
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        public IActionResult GetByGender(bool isMale)
        {
            var teachers = _mapper.Map<List<Teacher>>(_teacherRepository.GetByGender(isMale).ToList());
            if (ModelState.IsValid)
            {
                return Ok(teachers);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateTeacher([FromQuery] int subjectId,[FromBody] TeacherDto teacher)
        {
            if (teacher == null) return BadRequest(ModelState);

            var t = _teacherRepository.GetAllTeacher().Where(t => t.Name.Trim().ToUpper() == teacher.Name.Trim().ToUpper()).FirstOrDefault();
            if (t != null)
            {
                ModelState.AddModelError("", "Already Exists");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Not all completed");
                return BadRequest(ModelState);
            }
            var createdTeacher = _mapper.Map<Teacher>(teacher);
            createdTeacher.Subject = _subjectRepository.GetSubject(subjectId);
            if (!_teacherRepository.CreateTeacher(createdTeacher))
            {
                ModelState.AddModelError("", "Smth went wrong while saving");
                return BadRequest(ModelState);
            }
            return Ok("Successfully added");
        }

    }


}
