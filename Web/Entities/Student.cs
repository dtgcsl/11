using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Web.Entities.Common;

namespace Web.Entities
{
    public class Student : BaseEntity
    {
        /*Id,FullName,Gender,Address,Email,ClassId*/
        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;
        public bool Gender { get; set; }
        public string? Address { get; set; }
        [EmailAddress(ErrorMessage ="Not a valid email")]
        public string? Email { get; set; }
        [ForeignKey("ClassroomId")]
        public Guid? ClassroomId { get; set; }
        public virtual Classroom? Classroom { get; set; }
        public ICollection<Result>? Results { get; set; }

    }
}
