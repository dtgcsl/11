using Web.Models.Student;

namespace Web.Models.Classroom
{
    public class ClassroomDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string HomeroomTeacher { get; set; } = null!;
        public Guid? FacultyId { get; set; } 
        public StudentViewDto? Student {  get; set; }
    }
}
