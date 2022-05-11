using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BTL_TTCM.Data;
using System.Linq;

namespace BTL_TTCM.Models
{
   

    public class Cart
    {
        VegetableDbContext db;
        public Cart(VegetableDbContext db1)
        {
             db = db1;
        }

        [Key]
        public int CartId { get; set; }
        public int proID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float price { get; set; }
        public int quantity { get; set; }

        [ForeignKey("User")]
        public string Username { get; set; }
        public User User { get; set; }

        public float Amount
        {
            get{
                return price * quantity;
            }
        }

        public Cart(Product pro,int sl,string username)
        {
            proID = pro.ProductId;
            Name = pro.ProductName;
            Image = pro.Image;
            price = pro.oriprice;              
            Username = username;        
            quantity = sl;                    
        }

    }
}
