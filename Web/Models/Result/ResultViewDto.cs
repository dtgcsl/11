
namespace Web.Models.Result
{
    public class ResultViewDto
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid ClassroomId { get; set;}
        public Guid SujectId { get; set; }
        public int Point { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
