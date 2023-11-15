using System.ComponentModel.DataAnnotations;
using Web.Entities.Common;

namespace Web.Entities
{
    public class Subject : BaseEntity
    {
        /*Id,Name,NumberOfcredits*/
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = null!;
        [Range(2, 8 ,ErrorMessage = "Please enter a value between {2} and {8}")]
        public int NumberOfCredits { get; set; }

        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public ICollection<Result>? Results { get; set; }
    }
}
