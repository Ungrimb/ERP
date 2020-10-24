using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ERP.Data
{
    public interface IDataRepository<T> where T: class, IEntity
    {
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(long Id);
        Task<T> SaveAsync(T entity);
        Task<T> Get(long Id);
        Task<List<T>> GetAll();

    }
}
