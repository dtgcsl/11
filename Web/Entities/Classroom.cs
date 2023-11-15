using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Entities.Common;

namespace Web.Entities
{
    public class Classroom : BaseEntity
    {
        /*Id,Name,HomeroomTeacher,FacultyId*/
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        public string? HomeroomTeacher { get; set; }

        [ForeignKey("FacultyId")]
        public Guid? FacultyId { get; set; }
        public Faculty? Faculty { get; set; } 
        public ICollection<Student>? Students { get; set; }
    }
}
