using Microsoft.AspNetCore.Mvc;
using Northwind.BL.Abstract;
using NorthWind.Api.Models;
using Northwind.Entites.Entities;
using Northwind.Entites.Sakila;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCategoryController(IMySqlCategory mySqlCategory,IMsSqlCategory msSqlCategory) : ControllerBase
    {
        // GET: api/<MyCategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<MyCategoryDto> categories = new List<MyCategoryDto>();
            var sqlCategories = await msSqlCategory.GetAllAsync(null);//SqlServerdan kategoriler Cekilir
            var mySqlCategories = await mySqlCategory.GetAllAsync(null); // MySql'den kategoriler Cekilir
            foreach (var item in mySqlCategories) // MySql'den gelenler işlenir
            {
                MyCategoryDto cat = new()
                {
                    Id = item.CategoryId,
                    CategoryName = item.Name,
                    Source = "MySql"
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

        // GET api/<MyCategoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MyCategoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MyCategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MyCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
