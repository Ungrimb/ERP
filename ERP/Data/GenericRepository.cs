using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Data
{
    public class GenericRepository <T> : IGenericRepository<T> where T : class,new()
    {

        private readonly ERPContext _dbcontext;

        public GenericRepository(ERPContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<T> Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(Add)} entity must not be null");
            }

            try
            {
                await _dbcontext.AddAsync(entity);
                await _dbcontext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async virtual Task<T> Update(T entity)
        {
            if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(Update)} entity must not be null");
        }

        try
        {
            _dbcontext.Update(entity);
            await _dbcontext.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
        }
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

        //public async Task<List<T>> GetAll()
        //{
        //    return await _dbcontext.Set<T>().ToListAsync();
        //}

        public IQueryable<T> GetAll()
        {
            try
            {
                return _dbcontext.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

    }
}
