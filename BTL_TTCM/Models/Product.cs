using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_TTCM.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [Display(Name ="Product name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Descriptions")]
        public string Descriptions { get; set; }

        [Required]
        [Display(Name = "Supplier")]
        public string Supplier { get; set; }
        [Required]
        [Display(Name = "Producer")]
        public string Producer { get; set; }

        [Required]
        [Display(Name = "Product image")]
        public string Image { get; set; }
        [Required]
        [Display(Name = "Product price")]
        public float oriprice { get; set; }

        [ForeignKey("Category")]
        public int? CatId { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

        public Product()
        {

        }

    }
}
