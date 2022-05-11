using BTL_TTCM.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_TTCM.Models
{
    public class OrderDetail
    {
        VegetableDbContext db;
        public OrderDetail(VegetableDbContext db1)
        {
            db = db1;
        }
        [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order order { get; set; }

        [ForeignKey("Product")]
        public int? ProductId { get; set; }
        public Product product { get; set; }

        public float price { get; set; }
        public int quantity { get; set; }

		public OrderDetail(int oid,Cart c)
		{
            OrderId = oid;
            ProductId = c.proID;
            price = c.price;
            quantity = c.quantity;
        }
    }
}
