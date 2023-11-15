using Web.Models.Student;

namespace Web.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentViewDto>> GetAllStudents();
        Task<StudentDto> GetStudentById(Guid id);
        Task<List<StudentViewDto>> GetStudentByName(string name);
        Task<StudentViewDto> AddStudent(CreateStudentDto createStudentDto);
        Task<StudentViewDto> UpdateStudent(Guid id,UpdateStudentDto updateStudentDto);
        Task<StudentViewDto> DeleteStudent(Guid id);
        //Task<double> GetAverageStudentPoint(int id);
    }
}
