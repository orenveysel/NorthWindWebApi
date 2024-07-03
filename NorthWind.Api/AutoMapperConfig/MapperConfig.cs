using AutoMapper;
using Northwind.Entites.Sakila;
using NorthWind.Api.Models;

namespace NorthWind.Api.AutoMapperConfig
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<MyCustomerInsertDTO, Customer>();
            CreateMap<MyCustomerDTO, Customer>();
            CreateMap<Customer, MyCustomerInsertDTO >();

        }
    }
}
