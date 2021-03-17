using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROM.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public float Quantity { get; set; }
        public DateTime DateTime { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
