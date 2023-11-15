
using Web.Models.Classroom;

namespace Web.Models.Faculty
{
    public class FacultyDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public ClassroomViewDto? Classroom { get; set; }
    }
}
