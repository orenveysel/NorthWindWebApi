using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NorthwindWeb.RazorPage.Pages.Shippers
{
    public class UpdateModel : PageModel
    {
        public int EntityId { get; set; }
        public void OnGet(int itemid)
        {
            EntityId = itemid;
        }
    }
}
