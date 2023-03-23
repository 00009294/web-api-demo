using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.Demo.Dto;
using Web.API.Demo.Interfaces;
using Web.API.Demo.Models;

namespace Web.API.Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Subject>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllSubject()
        {
            var sb = _mapper.Map<List<SubjectDto>>(_subjectRepository.GetAllSubject());
            if (ModelState.IsValid)
            {
                return Ok(sb);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Subject))]
        [ProducesResponseType(400)]
        public IActionResult GetSubject(int id)
        {
            if (!_subjectRepository.IsExist(id))
            {
                return NotFound();
            }
            var sb = _mapper.Map<SubjectDto>(_subjectRepository.GetSubject(id));
            if (ModelState.IsValid)
            {
                return Ok(sb);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Subject))]
        [ProducesResponseType(400)]
        public IActionResult GetByName(string name)
        {
            var sb = _mapper.Map<SubjectDto>(_subjectRepository.GetByName(name));
            if (ModelState.IsValid)
            {
                return Ok(sb);
            }
            return BadRequest(ModelState);
        }
        [HttpGet("{isCore}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Subject>))]
        [ProducesResponseType(400)]
        public IActionResult GetByCore(bool isCore)
        {
            var sb = _mapper.Map<List<SubjectDto>>(_subjectRepository.GetByCore(isCore));
            if (ModelState.IsValid)
            {
                return Ok(sb);
            }
            return BadRequest(ModelState);
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult CreateSubject([FromQuery]int teacherId, [FromQuery] int studentId, [FromBody] SubjectDto subject)
        {
            if (subject == null) return BadRequest(ModelState);
            var sb = _subjectRepository.GetAllSubject().Where(s=>s.Name.Trim().ToUpper() == subject.Name.Trim().ToUpper()).FirstOrDefault();
            if(sb != null)
            {
                ModelState.AddModelError("", "Already exists");
                return BadRequest(ModelState);
            }
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Not all completed!!!");
                return BadRequest(ModelState);
            }
            var createdSubject = _mapper.Map<Subject>(subject);
            //createdSubject.Teachers = _teacherRepository.GetTeacher(teacherId);
            
            if(!_subjectRepository.CreateSubject(teacherId,studentId,createdSubject))
            {
                ModelState.AddModelError("", "Smth went wrong while saving");
                return BadRequest(ModelState);      
            }
            return Ok("Successfully added");
        }
    }
}
