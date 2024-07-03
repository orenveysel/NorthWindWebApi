using Microsoft.AspNetCore.Mvc;
using Northwind.BL.Abstract;

namespace NorthwindWeb.MVCUI.Controllers
{
    public class ShipperController : Controller
    {
        private readonly IShipperManager shipperManager;

        public ShipperController(IShipperManager shipperManager)
        {
            this.shipperManager = shipperManager;
        }
        public async Task<IActionResult> Index()
        {
            var result = await shipperManager.GetAllAsync(null);
            return View();
        }
    }
}
