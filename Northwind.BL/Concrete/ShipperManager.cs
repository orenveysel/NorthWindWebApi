using Northwind.BL.Abstract;
using Northwind.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BL.Concrete
{
    public class ShipperManager : Manager<NorthwindContext, Shipper>, IShipperManager
    {
        public ShipperManager(NorthwindContext context) : base(context)
        {
        }
    }
}
