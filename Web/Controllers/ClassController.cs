using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Web.Contracts;
using Web.Entities;
using Web.Interfaces;
using Web.Models.Classroom;
using Web.Models.Student;

namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly IClassService _classService;
        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        // GET: api/Classroom
        [HttpGet]
        public async Task<ActionResult<List<ClassroomViewDto>>> GetClassrooms()
        {
            return Ok(await _classService.GetAllClassrom());
        }

        // GET: api/Classroom/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ClassroomViewDto>> GetById(Guid id)
        {
            return Ok(await _classService.GetClassroomById(id));
        }

        // POST: api/Classroom
        [HttpPost]
        public async Task<ActionResult<ClassroomViewDto>> PostClassroom(CreateClassroomDto createClassroomDto)
        {
            return Ok(await _classService.AddClassroom(createClassroomDto));
        }

        // UPDATE: api/Classroom/1
        [HttpPatch("{id}")]
        public async Task<ActionResult<ClassroomViewDto>> PutClassroom(Guid id, UpdateClassroomDto updateClassroomDto)
        {
            return Ok(await _classService.UpdateClassroom(id,updateClassroomDto));
        }

        // DELETE: api/Classroom/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClassroomViewDto>> DeleteClassroom(Guid id)
        {
            return Ok(await _classService.DeleteClassroom(id));
        }

        [HttpGet("AllStudentsInClass/{id}")]
        public async Task<ActionResult<List<StudentViewDto>>> GetClassrooms(Guid id)
        {
            return Ok(await _classService.GetAllStudentsInClass(id));
        }

        [HttpGet("TopPointsStudentInClass/{id}")]
        public async Task<ActionResult<Object>> GetTopPointsStudentInClass(Guid id)
        {
            return Ok(await _classService.GetTopPointsStudentInClass(id));
        }

    }
}
