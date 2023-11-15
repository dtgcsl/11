using Web.Models.Classroom;
using Web.Models.Student;

namespace Web.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassroomViewDto>> GetAllClassrom();
        Task<ClassroomViewDto> GetClassroomById(Guid id);
        Task<ClassroomViewDto> AddClassroom(CreateClassroomDto createStudentDto);
        Task<ClassroomViewDto> UpdateClassroom(Guid id, UpdateClassroomDto updateClassroomDto);
        Task<ClassroomViewDto> DeleteClassroom(Guid id);
        Task<List<StudentViewDto>> GetAllStudentsInClass(Guid id);
        Task<Object> GetTopPointsStudentInClass(Guid id);
        Task<int> GetAverageInClass(Guid id);
    }
}
