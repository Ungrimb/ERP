using ERP.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERP.Data
{
    public abstract class DataRepository<T> : IDataRepository<T> 
        where T : class, IEntity 
    {

        private readonly ERPContext _context;

        public DataRepository(ERPContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> Update(T entity)
        {
            _context.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> Delete(long Id)
        {
            var entity = await _context.Set<T>().FindAsync(Id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(long Id)
        {
            return await _context.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
