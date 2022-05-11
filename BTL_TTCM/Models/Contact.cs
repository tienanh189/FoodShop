using System.ComponentModel.DataAnnotations;

namespace BTL_TTCM.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string YourComment { get; set; }
    }
}
