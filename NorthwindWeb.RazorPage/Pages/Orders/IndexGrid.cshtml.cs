using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Northwind.Entites.Entities;

namespace NorthwindWeb.RazorPage.Pages.Orders
{
    public class IndexGridModel(NorthwindContext context) : PageModel
    {

        public IQueryable<Order> Orders { get; set; }
        public void OnGet()
        {
            Orders = context.Orders
                .Include(p => p.Customer)
                .Include(p => p.Employee)
                .Include(p => p.ShipViaNavigation)
                .AsQueryable();
        }
    }
}
