using Northwind.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BL.Abstract
{
    public interface IShipperManager:IManager<NorthwindContext, Shipper>
    {
    }
}
