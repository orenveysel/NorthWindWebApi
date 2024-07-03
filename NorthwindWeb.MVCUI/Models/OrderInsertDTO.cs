using Microsoft.AspNetCore.Mvc.Rendering;

namespace NorthwindWeb.MVCUI.Models
{
    public class OrderInsertDTO
    {
        public SelectList CustomerList { get; set; }
        public SelectList EmployeeList { get; set; }
        public SelectList ShipperList { get; set; }

        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public int ShipperId { get; set; }

        public DateTime OrderDate { get; set; }
        public DateTime RequirDate { get; set; }

        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }

        public decimal  Freigth { get; set; }



    }
}