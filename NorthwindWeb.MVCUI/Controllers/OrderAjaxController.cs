using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Concrete;
using Northwind.Entites.Entities;

namespace NorthwindWeb.MVCUI.Controllers
{
    public class OrderAjaxController(NorthwindContext context) : Controller
    {
        public IActionResult Index()
        {
            var orders = context.Orders.Include(p => p.Customer)
                                .Include(p => p.Employee)
                                .Include(p => p.ShipViaNavigation)
                                .AsQueryable();

            // bize gelen isteklerin header bilgisi icerisinde XMLHttpRequest 
            // degeri varsa bu bir ajax istegidir
            if (HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_IndexGrid", orders);

           


            return View(orders);
        }
    }
}
