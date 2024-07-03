using Northwind.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Abstract
{
    public interface IShipperRepository
    {

        Task<int> AddAsync(Shipper input);
        Task<int> UpdateAsync(Shipper input);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(Shipper input);
        Task<Shipper?> GetByIdAsync(int id);
        Task<Shipper?> GetByAsync(Expression<Func<Shipper, bool>>? filter);
        Task<List<Shipper>?> GetAllAsync(Expression<Func<Shipper, bool>>? filter);
        Task<List<Shipper>?> GetAllIncludeAsync(Expression<Func<Shipper, bool>>? filter, params Expression<Func<Shipper, object>>[]? include);

    }
}
