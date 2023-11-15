using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Entities.Common;

namespace Web.Entities
{
    public class Result : BaseEntity
    {
        /*StudentId,ClassId,SubbectId,Point*/
        [ForeignKey("StudentId")]
        public Guid? StudentId { get; set; }
        [ForeignKey("ClassroomId")]
        public Guid? ClassroomId { get; set;}
        [ForeignKey("SujectId")]
        public Guid? SujectId { get; set; }
        [Range(0,int.MaxValue, ErrorMessage ="Please enter a value bigger or equal {0}")]
        public int Point { get; set; }
        public Student? Student { get; set; }
        public Classroom? Classroom { get; set; }
        public Subject? Subject { get; set; }
    }
}
