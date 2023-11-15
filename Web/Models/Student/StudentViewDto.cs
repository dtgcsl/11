namespace Web.Models.Student
{
    public class StudentViewDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public bool Gender { get; set; }
        public string Address { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Guid? ClassroomId { get; set; }
    }
}
