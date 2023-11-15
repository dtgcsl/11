namespace Web.Models.Faculty
{
    public class FacultyViewDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
