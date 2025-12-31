using System.ComponentModel.DataAnnotations;

namespace Compression_Force.Models
{
    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string AccessLevel { get; set; }

        // Privileges
        public bool Recipe { get; set; }
        public bool Operation { get; set; }
        public bool Diagnostic { get; set; }
        public bool Reports { get; set; }
        public bool Batch { get; set; }
    }
}
