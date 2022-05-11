using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_TTCM.Models
{
    public class Category
    {
        [Key]
        [Display(Name = "Category ID")]
        public int CatId { get; set; }
        [Required]
        [Display(Name ="Category name")]
        public string CatName { get; set; }

        public ICollection<Product> products { get; set;} 
 
    }
}
