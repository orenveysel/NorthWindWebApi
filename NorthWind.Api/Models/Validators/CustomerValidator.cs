using FluentValidation;
using Northwind.Entites.Sakila;

namespace NorthWind.Api.Models.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.AddressId)
                .InclusiveBetween((ushort)1, ushort.MaxValue)
                .WithMessage("1-65555 arasinda olabilir")
                .NotEmpty()
                .WithMessage("AddressId Boş olamaz")
                .NotNull()                
                .WithMessage("AddressId null olamaz");


            //RuleFor(p=>p.AddressId).NotEmpty().WithMessage("AddressId alani boş geçilemez");
            RuleFor(p => p.StoreId)
                .InclusiveBetween((byte)1, byte.MaxValue)
                .WithMessage("1-255 arasinda olabilir")
                .NotEmpty()
                .WithMessage("StoreId Boş olamaz")
                .NotNull()
                .WithMessage("StoreId null olamaz");

            RuleFor(p => p.Email)
                .EmailAddress()
                .WithMessage("Email alani Duzgun Formatta olmalidir");

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Isim alani Zorunludur");
            
            RuleFor(p => p.LastName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Soyadi alani Boş Gecilemez");
        }
    }
}
