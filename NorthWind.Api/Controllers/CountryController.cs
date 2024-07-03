using Microsoft.AspNetCore.Mvc;
using Northwind.BL.Abstract;
using Northwind.Entites.Sakila;

namespace NorthWind.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly IManager<SakilaContext, Country> countryManager;

        public CountryController(IManager<SakilaContext,Country> countryManager)
        {
            this.countryManager = countryManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await countryManager.GetAllAsync(null);
            return Ok(result);
        }
    }
}
