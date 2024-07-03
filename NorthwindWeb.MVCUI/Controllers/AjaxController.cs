using Microsoft.AspNetCore.Mvc;
using NorthwindWeb.MVCUI.Models;

namespace NorthwindWeb.MVCUI.Controllers
{
    public class AjaxController : Controller
    {
        public IActionResult Index()
        {
            Category category = new Category();
            return View(category);
        }

        [HttpPost]
        public IActionResult KategoryEkle([FromForm] Category category)
        {
           
            string str = "";
            return Ok("Islem Tamam");
        }




    }
   
}
