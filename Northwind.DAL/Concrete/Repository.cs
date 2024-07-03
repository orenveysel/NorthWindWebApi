using Microsoft.EntityFrameworkCore;
using Northwind.DAL.Abstract;
using Northwind.Entites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAL.Concrete
{
    public class Repository<TContext,T> : IRepository<T> 
        where T : class
        where TContext : DbContext ,new()
    {
        private readonly TContext context;

        public Repository(TContext context)
        {
            this.context = context;
        }


        public async Task<int> AddAsync(T input)
        {
            await  context.Set<T>().AddAsync(input);
            var result =  await context.SaveChangesAsync(); 
            return result;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return 0;
            }
             context.Set<T>().Remove(entity);
            var result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteAsync(T input)
        {
            context.Set<T>().Remove(input);
            var result = await context.SaveChangesAsync();
            return result;
        }

        public async Task<List<T>?> GetAllAsync(Expression<Func<T, bool>>? filter)
        {
            if (filter != null)
                return await context.Set<T>().Where(filter).ToListAsync();
            else
                return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>?> GetAllIncludeAsync(Expression<Func<T, bool>>? filter, params Expression<Func<T, object>>[]? include)
        {
            IQueryable<T> query;
            if (filter != null)
            {
                query = context.Set<T>().Where(filter);
            }
            else
            {
                query = context.Set<T>();
            }

            return await include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).ToListAsync();

        }

        public async Task<T?> GetByAsync(Expression<Func<T, bool>>? filter)
        {
            return await context.Set<T>().Where(filter).FirstOrDefaultAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<int> UpdateAsync(T input)
        {
              context.Set<T>().Update(input);
            return await context.SaveChangesAsync();
        }
    }
}
