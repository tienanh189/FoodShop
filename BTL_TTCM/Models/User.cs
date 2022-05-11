using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_TTCM.Models
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(\d{10})$",
        ErrorMessage = "Invalid Phone format")]
        public string PhoneNumber { get; set;}
        [Required]
        public string FullName { get; set;}
        public bool Role { get; set;}
        public ICollection<Order> Order { get; set;}
        public ICollection<Cart> Cart { get; set;}

    }
}
