using System.ComponentModel.DataAnnotations;
using Web.Entities.Common;

namespace Web.Entities
{
    public class Faculty : BaseEntity
    {

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<Classroom>? Classrooms { get; set; }
    }
}
