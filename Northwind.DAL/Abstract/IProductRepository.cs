using Northwind.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Abstract
{
    public interface IProductRepository
    {
        Task<int> AddAsync(Product input);
        Task<int> UpdateAsync(Product input);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(Product input);
        Task<Product?> GetByIdAsync(int id);
        Task<Product?> GetByAsync(Expression<Func<Product, bool>>? filter);
        Task<List<Product>?> GetAllAsync(Expression<Func<Product, bool>>? filter);
        Task<List<Product>?> GetAllIncludeAsync(Expression<Func<Product, bool>>? filter, params Expression<Func<Product, object>>[]? include);
    }
}
