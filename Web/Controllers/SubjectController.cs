using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using Web.Models.Subject;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<ActionResult<List<SubjectDto>>> GetAll()
        {
            return Ok(await _subjectService.GetAllSubjects());
        }



        // GET: api/Subject/1
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectDto>> GetById(Guid id)
        {
            return Ok(await _subjectService.GetSubjectById(id));
        }

        // POST: api/Subject
        [HttpPost]
        public async Task<ActionResult<SubjectDto>> Add(CreateSubjectDto SubjectDto)
        {
            return Ok(await _subjectService.AddSubject(SubjectDto));
        }

        // UPDATE: api/Subject/1
        [HttpPatch("{id}")]
        public async Task<ActionResult<List<SubjectDto>>> Update(Guid id, UpdateSubjectDto SubjectDto)
        {
            return Ok(await _subjectService.UpdateSubject(id, SubjectDto));
        }

        // DELETE: api/Subject/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubjectDto>> DeleteSubject(Guid id)
        {
            return Ok(await _subjectService.DeleteSubject(id));
        }

        // GET: api/Subject/giang
        [HttpGet("name/{username}")]
        public async Task<ActionResult<List<SubjectDto>>> GetByName(string username)
        {
            return Ok(await _subjectService.GetSubjectByName(username));
        }
    }
}
