using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
