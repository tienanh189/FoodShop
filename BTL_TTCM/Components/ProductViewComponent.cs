using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BTL_TTCM.Data;
using BTL_TTCM.Models;
using System.Collections.Generic;
using System.Linq;

namespace BTL_TTCM.Compoment
{
	public class ProductViewComponent : ViewComponent
	{
		private readonly VegetableDbContext db;
		public ProductViewComponent(VegetableDbContext db1)
		{
			db =db1;
		}
		public async Task<IViewComponentResult> InvokeAsync(int catID)
		{			
			if(catID == 0)
            {
				IEnumerable<Product> obj = db.products;
				return View(obj);
			}		
			var product = from p in db.products
						where p.CatId == catID
						select p;	
			return View(product);
			
		}


	}
}
