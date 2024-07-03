using System.ComponentModel.DataAnnotations;

namespace NorthWind.Api.Models
{
    public class MyCustomerDTO
    {
       
        public byte StoreId { get; set; }
      
        public ushort AddressId { get; set; }

       
        public string FirstName { get; set; } = null!;
    

        public string LastName { get; set; } = null!;

      
        public string? Email { get; set; }
    }
}
