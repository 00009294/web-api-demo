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
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
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

    }
}
