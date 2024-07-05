using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.Entites.Entities;

namespace NorthwindWeb.RazorPage.Pages.Orders
{
    public class IndexModel(NorthwindContext context) : PageModel
    {

        public void OnGet()
        {
        }
    }
}
