using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Northwind.Entites.Entities;

namespace NorthwindWeb.RazorPage.Pages.Shippers
{
    public class CreateModel(NorthwindContext context) : PageModel
    {
        [BindProperty]
        public Shipper Shipper { get; set; }
        public void OnGet()
        {
            Shipper = new Shipper();
        }
        public IActionResult OnPost(Shipper shipper) 
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            context.Shippers.Add(shipper);
            context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
