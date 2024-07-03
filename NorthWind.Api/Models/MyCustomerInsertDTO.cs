using System.ComponentModel.DataAnnotations;

namespace NorthWind.Api.Models
{
    public class MyCustomerInsertDTO
    {
        [Range(1, byte.MaxValue, ErrorMessage = "Girilen deger 1-255 arasinda olmalidir ")]
        public byte StoreId { get; set; }
        [Range(1, ushort.MaxValue, ErrorMessage = "Girilen deger 1-65535 arasinda olmalidir ")]
        public ushort AddressId { get; set; }

        [Required(ErrorMessage ="isim alani zorunludur")]
        public string FirstName { get; set; } = null!;
        [Required(ErrorMessage = "Soyisim alani zorunludur")]

        public string LastName { get; set; } = null!;

        [EmailAddress(ErrorMessage ="Email adresi dogru girilmemistir")]
        public string? Email { get; set; }

    }
}
