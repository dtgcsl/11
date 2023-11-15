using Web.Models.Result;

namespace Web.Models.Student
{
    public class CreateStudentDto
    {
        public string FullName { get; set; } = null!;
        public bool Gender { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;

    }
}
