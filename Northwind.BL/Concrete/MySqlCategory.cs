using Northwind.BL.Abstract;
using Northwind.Entites.Sakila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BL.Concrete
{
    public class MySqlCategory : Manager<SakilaContext, Category>,IMySqlCategory
    {
        public MySqlCategory(SakilaContext context) : base(context)
        {
        }
    }
}
