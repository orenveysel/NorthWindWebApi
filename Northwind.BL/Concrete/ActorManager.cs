using Northwind.BL.Abstract;
using Northwind.Entites.Sakila;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BL.Concrete
{
    public class ActorManager : Manager<SakilaContext, Actor>, IActorManager
    {
        public ActorManager(SakilaContext context) : base(context)
        {
        }
    }
}
