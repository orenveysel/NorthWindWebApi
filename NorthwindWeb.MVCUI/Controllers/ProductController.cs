using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Entites.Entities;

namespace NorthwindWeb.MVCUI.Controllers
{
    public class ProductController(NorthwindContext context) : Controller
    {
        public IActionResult Index()
        {

            #region Metod Syntax ile Queryable Sorgu olustuma
            var products = context.Products
                                .Include(p=>p.Category)
                                .Include(p=>p.Supplier)
                                .AsNoTracking() // Çekilen datayi izleme
                                .AsQueryable(); // Sorgu taslagi olarak ver

            #endregion

            #region Query Syntax

            //var products2 = from p in context.Products
            //                join cat in context.Categories on p.CategoryId equals cat.CategoryId
            //                join sup in context.Suppliers on p.SupplierId equals sup.SupplierId
            //                select p;
            #endregion
            return View(products);
        }
    }
}
