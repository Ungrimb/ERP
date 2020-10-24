using ERP.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.UnitOfWork
{
    public class GenericUnitOfWork
    {
        private ERPContext _dbcontext = new ERPContext();
        public GenericRepository<T> GetRepoInstance<T>() where T : class
        {
            return new GenericRepository<T>(_dbcontext);
        }

    }
}
