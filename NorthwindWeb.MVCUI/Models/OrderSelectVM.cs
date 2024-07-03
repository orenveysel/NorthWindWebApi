namespace NorthwindWeb.MVCUI.Models
{
    public class OrderSelectVM
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public string Employee { get; set; }
        public string Shipper { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }

    }
}
 