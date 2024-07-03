using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.BL.Abstract;
using Northwind.Entites.Sakila;
using NorthWind.Api.Models;

namespace NorthWind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController(IManager<SakilaContext,Customer> manager,IMapper mapper,IValidator<Customer> validator) : ControllerBase
    {
        private readonly IValidator<Customer> validator = validator;

        [HttpGet]
       public async Task<IActionResult> Index()
        {
            var result = await  manager.GetAllAsync(null);
            return Ok(result);
        }


        // FluentValidation  Post islemi
        [HttpPost]
        public async Task<IActionResult> Create(MyCustomerDTO myCustomer)
        {
            var customer = mapper.Map<Customer>(myCustomer);
            var result =  validator.Validate(customer);  
            
            //Validation'dan gelen hatalari ModelState deki Error'larin icerisine ekler
            result.AddToModelState(this.ModelState);
            if (!ModelState.IsValid)
            {
                           
                
                return BadRequest(myCustomer);
            }

            

          
            int sonuc = await manager.AddAsync(customer);

            if (sonuc > 0)
            {
                return Created("İşlem Başarili", customer);
            }
            else
            {
                return BadRequest("Birseyler ters gitti");
            }

        }

        // System.DataAnnotation ile yapilan kontrol icin burasi
        //[HttpPost]
        //public async Task<IActionResult> Create(MyCustomerInsertDTO myCustomer)
        //{


        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(myCustomer);
        //    }

        //    //Customer customer = new Customer
        //    //{
        //    //    AddressId = myCustomer.AddressId,
        //    //    FirstName = myCustomer.FirstName,
        //    //    LastName = myCustomer.LastName,
        //    //    StoreId = myCustomer.StoreId,
        //    //    Email = myCustomer.Email
        //    //};

        //    var customer = mapper.Map<Customer>(myCustomer);

        //   int sonuc =  await manager.AddAsync(customer);

        //    if (sonuc > 0)
        //    {
        //        return Created("İşlem Başarili",customer);
        //    }
        //    else
        //    {
        //        return BadRequest("Birseyler ters gitti");
        //    }

        //}
    }
}
