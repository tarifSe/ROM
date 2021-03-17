using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [NotMapped]
        public List<Category> Categories { get; set; }
    }
}
