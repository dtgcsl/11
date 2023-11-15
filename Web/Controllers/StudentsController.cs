using Microsoft.AspNetCore.Mvc;
using Web.Interfaces;
using Web.Models.Student;

namespace Web.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;


        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<ActionResult<List<StudentDto>>> GetAll()
        {
            return Ok(await _studentService.GetAllStudents());
        }

       

        // GET: api/Student/1
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDto>> GetById(Guid id)
        {
            return Ok(await _studentService.GetStudentById(id));
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult<StudentDto>> Add(CreateStudentDto StudentDto)
        {
            return Ok(await _studentService.AddStudent(StudentDto));
        }

        // UPDATE: api/Student/1
        [HttpPatch("{id}")]
        public async Task<ActionResult<List<StudentDto>>> Update(Guid id, UpdateStudentDto StudentDto)
        {
            return Ok(await _studentService.UpdateStudent(id, StudentDto));
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDto>> DeleteStudent(Guid id)
        {
            return Ok(await _studentService.DeleteStudent(id));
        }

        // GET: api/Student/giang
        [HttpGet("name/{username}")]
        public async Task<ActionResult<List<StudentDto>>> GetByName(string username)
        {
            return Ok(await _studentService.GetStudentByName(username));
        }

        // GET: api/getByClass/cntt1
        //[HttpGet("class/{classname}")]
        //public async Task<ActionResult<StudentDto>> GetAllByClass(string name)
        //{
        //    return Ok(await _studentService.GetStudentsByClass(name));
        //}

        // GET: api/getTop/cntt1
        //[HttpGet("getTop/{classname}")]
        //public async Task<ActionResult<StudentDto>> GetTopOnePoint(string name)
        //{
        //    return Ok(await _studentService.GetTopOnePoint(name));
        //}

        // GET: api/getAverage/1
        //[HttpGet("getAverageStudent/{id}")]
        //public async Task<IActionResult> GetAverageStudentPoint(int id = 1)
        //{
        //    return Ok(await _studentService.GetAverageStudentPoint(id));
        //}

        // GET: api/getAverage
        //[HttpGet("getAverageClass/{classname}")]
        //public async Task<IActionResult> GetAverage(string classname = "cntt1")
        //{
        //    return Ok(await _studentService.GetAverageOfClass(classname));
        //}
    }
}
