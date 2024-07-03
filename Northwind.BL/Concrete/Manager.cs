using Microsoft.EntityFrameworkCore;
using Northwind.BL.Abstract;
using Northwind.DAL.Concrete;
using Northwind.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BL.Concrete
{
    public class Manager<TContext,T> : Repository<TContext,T>, IManager<TContext,T> 
        where T : class
        where TContext : DbContext,new()
    {
        public readonly TContext context;

        public Manager(TContext context) : base(context)
        {
            this.context = context;
        }
    }
}
