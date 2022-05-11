using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_TTCM.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime dateCreate { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }
        public User User { get; set; }
        public bool status { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } 

    }
}
