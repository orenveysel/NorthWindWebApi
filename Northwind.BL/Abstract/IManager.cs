using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BL.Abstract
{
    public interface IManager<TContext ,T> : IRepository<T> 
        where T : class
        where TContext : DbContext
    {

    }
}
