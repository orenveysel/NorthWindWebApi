using Microsoft.AspNetCore.Mvc;
using Northwind.BL.Abstract;
using Northwind.Entites.Entities;
using NorthwindWeb.MVCUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;
using Microsoft.Data.SqlClient;

namespace NorthwindWeb.MVCUI.Controllers
{
    public class OrderController(NorthwindContext context) : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            /*
           *  ihtiyaç duyacağımız 1 sayfa içerisinde kaç adet satır bulunacak kısmını ise Index methodunun içerisinde parametre olarak barındırıyoruz . Methodun gövdesinde ise PagedList üzerinden instance alıyoruz ve hangi nesne üzerinde çalışması gerektiğini 1 sayfa üzerinde kaç satır veri gözükmesi gerekiyor pagedlist nesnesi içerisine bunları parametre olarak giriyoruz.Methodun dönüş tarafında ise View kısmına yönlendirirken model ile beraber gönderiyoruz ki sayfalama yaptığımız her veriyi taşıyabilelim. Tüm bu aşamaları geçtikten sonra bir adet view eklememiz gerekmekte fakat View eklemeden önce son bir kısım daha var o da ViewImport . Uygulama içerisinde aslında uygulama yerine birden fazla view içerisinde ortak olarak kullanılmasını beklediğimiz directiveleri topladığımız bir yer var orası da ViewImport 
           * 
           * 
           */

            #region Metod Syntax
            //var selectVm = context.Orders
            //       .Include(p => p.Customer)
            //       .Include(p => p.Employee)
            //       .Include(p => p.ShipViaNavigation)
            //       .Select(p => new OrderSelectVM
            //       {
            //           OrderId = p.OrderId,
            //           Customer = p.Customer.CompanyName,
            //           Employee = p.Employee.FirstName + " " + p.Employee.LastName,
            //           Shipper = p.ShipViaNavigation.CompanyName,
            //           OrderDate = p.OrderDate,
            //           ShipCity = p.ShipCity,
            //           ShipCountry = p.ShipCountry

            //       }).ToList(); 
            #endregion




            #region Query Syntax
            var result = from order in context.Orders
                          join customer in context.Customers on order.CustomerId equals customer.CustomerId
                          join employee in context.Employees on order.EmployeeId equals employee.EmployeeId
                          join shipper in context.Shippers on order.ShipVia equals shipper.ShipperId
                          select new OrderSelectVM
                          {
                              OrderId = order.OrderId,
                              Customer = order.Customer.CompanyName,
                              Employee = order.Employee.FirstName + " " + order.Employee.LastName,
                              Shipper = order.ShipViaNavigation.CompanyName,
                              OrderDate = order.OrderDate,
                              ShipCity = order.ShipCity,
                              ShipCountry = order.ShipCountry
                          };
            #endregion

            //PagedList<OrderSelectVM> model = new PagedList<OrderSelectVM>(result, page, pageSize);
            return View("Index", result);
        }
        public IActionResult Create()
        {
            OrderInsertDTO dTO = new OrderInsertDTO();
            dTO.ShipperList = new SelectList(context.Shippers.ToList(), "ShipperId", "CompanyName");
            dTO.CustomerList = new SelectList(context.Customers.ToList(), "CustomerId", "CompanyName");
            dTO.EmployeeList = new SelectList(context.Employees.ToList(), "EmployeeId", "FirstName");
            return View(dTO);
        }

        [HttpPost]
        public IActionResult Create(OrderInsertDTO dto)
        {
            if(!ModelState.IsValid) 
            {
                return View(dto);
            }
            Order order = new Order
            {
                CustomerId=dto.CustomerId,
                EmployeeId=dto.EmployeeId,
                ShipVia=dto.ShipperId
            };
            context.Orders.Add(order);
            context.SaveChanges();
            return View(dto);
        }
        public IActionResult OrderDetail(int id)
        {
            var  result = context.OrderDetails.Include(p=>p.Product).Where(p=>p.OrderId==id).ToList();
            return View(result);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
