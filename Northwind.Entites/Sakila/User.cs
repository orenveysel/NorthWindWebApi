﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Entites.Sakila
{
    public class User
    {
       
        public int Id { get; set; }
      
        public string? Name { get; set; }
       
        public string? Surname { get; set; }
      
        public string Email { get; set; }
        
        public string Password { get; set; }
       
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
