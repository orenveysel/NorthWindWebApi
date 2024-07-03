using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Entites.Entities;
using Northwind.Entites.Sakila;
using NorthWind.Api.Models;

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(NorthwindContext northwindContext,SakilaContext sakilaContext) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            List<MyCategoryDto> categories = new List<MyCategoryDto>();
            var sqlCategories = northwindContext.Categories.ToList();//SqlServerdan kategoriler Cekilir
            var mySqlCategories = sakilaContext.Categories.ToList(); // MySql'den kategoriler Cekilir
            foreach (var item in mySqlCategories) // MySql'den gelenler işlenir
            {
                MyCategoryDto cat = new()
                {
                    Id=item.CategoryId,
                    CategoryName=item.Name,
                    Source="MySql"
                };
                categories.Add(cat);
            }
            foreach (var item in sqlCategories)// MsSql'den gelenler işlenir
            {
                MyCategoryDto cat = new()
                {
                    Id = item.CategoryId,
                    CategoryName = item.CategoryName,
                    Source = "MsSql"
                };
                categories.Add(cat);
            }

            return Ok(categories);
        }
    }
}
