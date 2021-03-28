using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Required]
        public float Quantity { get; set; }
        [Required]
        public DateTime DateTime { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; }
        [Display(Name ="Food Item")]
        public int FoodId { get; set; }
        public Food Food { get; set; }

        [NotMapped]
        public List<Member> Members { get; set; }
        [NotMapped]
        public List<Food> Foods { get; set; }
    }
}
