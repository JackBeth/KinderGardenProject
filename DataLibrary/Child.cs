using System;
using System.ComponentModel.DataAnnotations;

namespace Data
{
    public class Child
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Key]
        [Required]
        [Range(3, 6, ErrorMessage ="Age must be between 3 and 6")]
        public int Age { get; set; }

        [Required]
        public string Gender { get; set; }

    }
}
