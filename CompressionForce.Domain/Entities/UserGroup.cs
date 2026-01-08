using System.ComponentModel.DataAnnotations;

namespace Compression_Force.Domain.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "";
    }
}
