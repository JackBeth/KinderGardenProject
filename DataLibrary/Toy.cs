using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data
{
    public class Toy
    {
        [Key]
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public Child ChildOwnerOfToy { get; set; }

        public string Color { get; set; }

        public string Condition { get; set; }

        public Boolean IsFavorite { get; set; }
    }
}
