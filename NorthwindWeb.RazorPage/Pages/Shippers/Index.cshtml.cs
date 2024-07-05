using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.Entites.Entities;

namespace NorthwindWeb.RazorPage.Pages.Shippers
{
    public class IndexModel(NorthwindContext context) : PageModel
    {
        public ICollection<Shipper> Shippers { get; set; }
        public void OnGet()
        {
            Shippers = context.Shippers.ToList();
        }
    }
}
