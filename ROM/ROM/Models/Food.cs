using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name="Price")]
        public double UnitPrice { get; set; }
    }
}
