using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class
    {

        private readonly ERPContext _dbcontext;

        public GenericRepository(ERPContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> Add(T entity)
        {
            _dbcontext.Set<T>().Add(entity);
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> Update(T entity)
        {
            _dbcontext.Entry(entity).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async virtual Task<T> Delete(long Id)
        {
            var entity = await _dbcontext.Set<T>().FindAsync(Id);
            if (entity == null)
            {
                return entity;
            }

            _dbcontext.Set<T>().Remove(entity);
            await _dbcontext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _dbcontext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(long Id)
        {
            return await _dbcontext.Set<T>().FindAsync(Id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _dbcontext.Set<T>().ToListAsync();
        }

    }
}
