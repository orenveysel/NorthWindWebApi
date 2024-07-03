using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Abstract
{
    public interface IRepository<T> where T: class
    {

        Task<int> AddAsync(T input);
        Task<int> UpdateAsync(T input);
        Task<int> DeleteAsync(int id);
        Task<int> DeleteAsync(T input);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByAsync(Expression<Func<T, bool>>? filter);
        Task<List<T>?> GetAllAsync(Expression<Func<T,bool>>? filter);
        Task<List<T>?> GetAllIncludeAsync(Expression<Func<T, bool>>? filter, params Expression<Func<T, object>>[]? include);
    }
}
