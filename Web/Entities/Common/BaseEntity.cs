
using System.ComponentModel.DataAnnotations;

namespace Web.Entities.Common
{
    public  class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
